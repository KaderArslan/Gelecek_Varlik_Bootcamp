using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Dal.Concrete.Entityframework.Repository;
using Workfollow.Entity.Base;

namespace Workfollow.Dal.Concrete.Entityframework.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        //derli toplu olsun diye
        #region Veriables
        DbContext context;
        //transaction yonetimi icin ise
        IDbContextTransaction transaction;
        //dispose yonetimi icin ise
        //dispose transaction yonetimi ile illgisi yok nesne yonetmek icin ekledik
        bool dispose; //default false'tur
        #endregion

        public UnitOfWork(DbContext context)
        {
            //context le baglicagiz
            //baglamamizin sebebi asagidakileri yonetmek icin onaylamamiz gerekiyor DbContext uzerinden onaylayabiliriz
            //transaction bir hareketle birden cok is yapabilmek aslinda, her bir hareket bir context olusturuyor
            //bir contextle butun her seyi bagliyoruz
            this.context = context;
        }

        public bool BeginTransaction()
        {
            //Bllde hata yonetimi yapacagiz
            try
            {
                //ORM kodlari
                //transactionu baslatti
                transaction = context.Database.BeginTransaction();
                //bos mu dolu mu kontrolude burada yapilir
                return true;

            }
            catch (Exception)
            {
                //transactionu baslatamiyorsa
                return false;
            }
        }

        //dispose yazma zorunlugumuz yok ama bellek yonetimi yapacagimizda hazir olmasi icin 
        public void Dispose()
        {
            Dispose(true);
            //hemde bunun disinda bir nesne varsa onuda oldur
            GC.SuppressFinalize(this); //garbage collector calistirir, cop toplama
        }

        //interface disinda bir metod yazabiliyoruz, disposing degisken
        protected virtual void Dispose(bool disposing)
        {
            //true mu oldurece miyiz (disposing), disposing bu ise yukaridaki Dispose'den gelecek
            if (!dispose)
            {
                if(disposing)
                {
                    context.Dispose();//hem kendi nesnemi oldurdum
                }
            }
            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            //ne istersek isteyelim contextle birlikte donecek
            //amac ilgili T yi verecegiz T ise mesela employee mesela requestdir 
            //amac modele ait tek bir insert updateyi tek bir contextle yonetebilmek
            return new GenericRepository<T>(context);//somutlastiriyoruz burada
        }

        public bool RollBackTransaction()
        {
            //hata yonetimi, hata varsa butun olayi geri alir, butunluk sagliyor
            try
            {
                //beginde boyle tanimladik diye nesnemiz artik transaction
                //problem varsa rollback metodunu cagirir
                transaction.Rollback();
                transaction = null; //daha onceki transactionu yok eder 
                return true;
            }
            catch (Exception)//hata firlatmak icin ex diyebiliriz
            {

                return false;
            }
        }

        public int SaveChanges()
        {
            //transactionu onaylar savechanges

            //transaction var mi? baslatilmis mi kontrol ediyoruz, null dan farkli mi farkli ise transaction vardir
            //eger yoksa null sa demek ki yok transaction olustur
            //regionda tanimladigimiz transaction nesnem bu 
            var _transaction = transaction !=null ? transaction : context.Database.BeginTransaction(); 
            //veriyi yonetmek icin using olusturuyoruz, hata olsada olmasada is bitince bunu yok et anlaminda using
            using (_transaction)//islem bitince yok et
            {
                try
                {
                    //context nullda islem yapamayiz 
                    if(context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }

                    //context doludur, insert update delete hepsi savechanges calistiti ve etkilenen satir sayisini dondurur
                    int result = context.SaveChanges();//bu calisirsa hata yok demektir

                    //commit transactonun onaylandigi yerdir
                    _transaction.Commit();//isin bittigi anlamina gelir kac tane adrese isaretlenmis veri varsa onaylanir

                    return result;  //etkilenen satir sayisini dondur
                }
                catch (Exception ex)
                {
                    //hata olma durumunda islem geri alinir
                    transaction.Rollback();

                    throw new Exception("Error on save changes", ex);
                }
            }
        }
    }
}
