using System.Collections.Generic;
using Workfollow.Entity.IBase;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Workfollow.Interface
{
    //ortak islemleri generic ile yapacagiz
    //T modeli ifade eder, TDto ise Dto yu ifade eder, where ile tipini belirtiyoruz
    //T nin model tiinde oldugunu belirtiyoruz IEntityBase ile
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        //Listeleme (tum personelleri getir)
        IResponse<List<TDto>> GetAll();

        //--------//

        //Filreli Listeleme (ankarada yasayan filtreleme gibi) -> filtre T donus tipi TDto olur
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        //bool 1 1 e esit mi gibi, vertabani modeli uzerinden filtreleme yaptigimiz icin T

        //--------//

        //Find, Getirme (Bulma islemi 1 numarali employee getir gibi, 1 idli employee yi getir gibi)
        //nesne dondurur, 1 idli employee yi getir
        IResponse<TDto> Find(int id);

        //--------//

        //Ekleme, Kaydetme -> TDto veririz donus tipi T olur
        //kaydedilen nesneyi doner, kaydetme klavyeden olur degerde klavyeden gelir, personel kaydetme
        //ilk parametre arayuz ikinci parametre veritabanı diye dusunebiliriz
        //is katmaninda TDto olar T ye donusecek modele
        //false dersek islemleri bitirdikten sonra kaydeder
        IResponse<TDto> Add(TDto item, bool saveChanges = true);
        //--------//

        //Async Kaydetme islemlerin birbirini beklememesi, c# senkron calisir
        Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true);
        //--------//

        //Guncelleme 
        //neden T degil -> service tasarladigimiz icin buda is katmanina implemente olacak, 
        //is katmanindan sonra ise burada bir mapper calisacak,Dal'in anlayacagi ture cevirecek 
        //Bllye veri ise Webapiden geldigi icin TDto olarak tasarladik
        IResponse<TDto> Update(TDto item, bool saveChanges = true);
        //--------//

        //Async Guncelleme
        Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);
        //--------//

        //Silme, int, bool gibi degerler donebilir, Insert, Update, Delete de asenkron yonetimi vardir
        IResponse<bool> DeleteById(int id, bool saveChanges = true);
        //--------//

        //Async Silme
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);
        //--------//

        //IQueryable Listeleme, bize TDto doner
        //veritabanında bir sorgu calistiracaksak bununla yapariz IQueryable
        //bellekte bir is yapacaksak IEnaryable ie yapilir
        IResponse<IQueryable<TDto>> GetQueryable();

        void Save(); 
        //diger ortak olabilecekler, kayit sayisini bulabilme gibi
    }
}
