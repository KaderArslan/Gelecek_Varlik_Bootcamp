using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Entity.Models;

namespace Workfollow.Dal.Concrete.Entityframework.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        //base ile ust sinifa gonderilir
        //base kalitim aldigim sinifa (GenericRepository) arguman gondermek icin kullanilir
        //contexti ayni tipli constructor'a gider
        public DepartmentRepository(DbContext context) : base(context)
        {

        }

        //this ise ilgili sinifta yani ayni sinifta constructor'dan constructor'a veri gondermek icin kullanilir  : this()
        //public IQueryable<Department> GetTotalReport()
        //{
        //selecte transection yok 
        //return dbset.AsQueryable<Department>();
        //return dbset.AsQueryable();
        //}
    }
}
