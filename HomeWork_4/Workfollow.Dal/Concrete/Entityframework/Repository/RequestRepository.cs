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
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Request> GetTotalReport()
        {
            return dbset.AsQueryable();
        }

        public Request Add(Request item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }


    }
}
