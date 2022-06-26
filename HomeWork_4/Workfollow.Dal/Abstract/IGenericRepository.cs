using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.IBase;

namespace Workfollow.Dal.Abstract
{
    //GenericRepositoryneler olacak
    //interface oldugu icin IEntityBase olur 
    //Dal katmaninin Dto ile isi yok
    public interface IGenericRepository<T> where T : IEntityBase
    {
        //Listeleme
        List<T> GetAll();

        //--------//

        //Filreli Listeleme
        List<T> GetAll(Expression<Func<T, bool>> expression);

        //--------//

        //Find, Getirme
        T Find(int id);

        //--------//

        //Ekleme, Kaydetme
        //transection Bll ve Dal katmani arasinda yonetilir emri veren Bll dir Dal gorev yapar bool saveChanges = true olmaz
        T Add(T item);
        //--------//

        //Async Kaydetme
        Task<T> AddAsync(T item);
        //--------//

        //Guncelleme 
        T Update(T item);
        //--------//

        //Async Guncelleme
        //Task<T> UpdateAsync(T item);uptatenin asenkronu yok
        //--------//

        //Silme
        bool Delete(int id);
        //ne kadar id gondersekte hep T siler
        bool Delete(T item);
        //--------//

        //Async Silme
        //Task<bool> DeleteAsync(int id);
        //--------//

        //IQueryable Listeleme
        IQueryable<T> GetQueryable();
    }
}
