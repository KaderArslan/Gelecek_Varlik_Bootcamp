using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Entity.Base;

namespace Workfollow.Dal.Concrete.Entityframework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        //bazi veriable ler yazmamiz gerekiyor iste dbset context gibi context tanimlicagiz
        //region blok olusturmak icin kullaniliyor
        //context nerede kullanilacak mesela burada ve kalitim verdigimiz yerde olacak
        //context tasarlicagiz

        #region Variables
        protected DbContext context;  //erisim tipi private'tir class icindeki degiskenler default private dir, class internal gelir
        protected DbSet<T> dbset;
        #endregion

        public GenericRepository(DbContext context)
        {
            //this koymazsak parametredeki contexti algilar ama biz yukaridaki contexti kullanmak istedigimizden this koyduk
            this.context = context;
            this.dbset = this.context.Set<T>();

            //bunu aktif edersek biz izin vermedigimiz surece o veri uzerinde degisiklik yapamayiz bu ozelligi var
            //veriyi cekebilirsin ama uzerinde degisiklik yapamazsin
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //aktif edersek metod uzerinde cozmek istersek bu sefer bir veriyi getirirken getirme
            //veya listeleme yaparken AsNoTracking olarak cekmemiz gerekiyor, ama degisiklik yapmamiza izin verir
            //bu kodu ve lazy loadingi aktif edersek bagililiklar gelmiyor
            //header loading istenildigi yerde istenilen detayi dahil et 
        }

        #region Methods
        

        //ekleme
        public T Add(T item)
        {
            //kayit edilen veri item kaydediyoruz
            context.Entry(item).State = EntityState.Added; //ekleme islemi var
            dbset.Add(item);//item kaydediyoruz, bellege aliyor

            //unitofwork olmasaydi
            //context.SaveChanges(); böyle commiti onaylardi

            return item;//kayit edilmis item, veritabanindaki id 'li hali
        }

        public async Task<T> AddAsync(T item)
        {
            context.Entry(item).State = EntityState.Added;
            await dbset.AddAsync(item);//bitmemis islemin cevabını dondurmemesi icin await ekledik
            return item;
        }

        public bool Delete(int id)
        {
            //itemi elde etmek icin tanimladik
            //var item = Find(id);//ilgili id ye ait Find metoduna gider nesneyi bulup getirir ve nesneyi sileriz
            //if(context.Entry(item).State == EntityState.Detached)
            //{
            //    context.Attach(item);
            //}
            //return dbset.Remove(item) != null;

            //ya da
            return Delete(Find(id));//asagidaki delete
        }

        public bool Delete(T item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public T Find(int id)
        {
            //Find bir modelde primary keye gore calisir
            return dbset.Find(id);
        }

        public List<T> GetAll()
        {
            return dbset.ToList();//tolist hepsini getirir
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();//sonucu Queryable dir
        }

        public IQueryable<T> GetQueryable()
        {
            return dbset.AsQueryable();
        }

        public T Update(T item)
        {
            dbset.Update(item);
            return item;
        }

        #endregion
    }
}
