using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Dal.Abstract
{
    //disposable yonetimi yapacagimiz icin disposable den kalitim alacak, nesneleri yonetebilmek icin,
    //gorbage collecteru yeri geldiginde tetikleyebilim diye yoksa bellekte kalir IESte sisme olabilir
    public interface IUnitofWork : IDisposable
    {
        //generic metod tasarimi, bll katmaninda kullanacam,
        //genericteki insertleri updateleri savecgange yapabilmek icin

        IGenericRepository<T> GetRepository<T>() where T : EntityBase; //Transaction inser update erismek icin bu metodu kullandik

        //transaction baslatma
        bool BeginTransaction();
        //RollBack hata durumunda surecin geri alinmasini saglayan islemdir
        bool RollBackTransaction();
        //Transaction onaylama
        int SaveChanges();

    }
}
