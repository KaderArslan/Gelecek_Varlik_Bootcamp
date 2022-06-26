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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {

        }

        public Employee Login(Employee login)
        {
            //SingleOrDefault herhangi bir veri yoksa null donderir
            //tekil veri girecegimizi on kosul koyuyorsak bu ideal yontem, hic veride olmasa null donderir, 
            //coklu veri gelirse hata verir o zamanda veritabanindan veriyi cozmek gerek 
            var employee = dbset.Where(x=>x.EmployeeEmail == login.EmployeeEmail && x.EmployeePassword == login.EmployeePassword).SingleOrDefault();

            //FirstOrDefault coklu gelebilir hicte gelmeyebilir, hic gelmeyen bir seyin firstunu alamayiz
            //gelen verinin ilkini al ya da boşsa default donder
            //var user = dbset.FirstOrDefault(x=>x.EmployeeEmail == login.EmployeeEmail && x.EmployeePassword == login.EmployeePassword);

            //tek al ya da boş gonder
            //var user = dbset.SingleOrDefault(x=>x.EmployeeEmail == login.EmployeeEmail && x.EmployeePassword == login.EmployeePassword);


            return employee;
        }

        public Employee Add(Employee item)
        {
            //kayit edilen veri item kaydediyoruz
            context.Entry(item).State = EntityState.Added; //ekleme islemi var
            dbset.Add(item);//item kaydediyoruz, bellege aliyor

            //unitofwork olmasaydi
            //context.SaveChanges(); böyle commiti onaylardi

            return item;//kayit edilmis item, veritabanindaki id 'li hali
        }

        public Employee Update(Employee item)
        {
            dbset.Update(item);
            return item;
        }

    }
}
