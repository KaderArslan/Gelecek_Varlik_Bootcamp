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
    public class JobListRepository : GenericRepository<JobList>, IJobListRepository
    {
        public JobListRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<JobList> GetTotalReport()
        {
            return dbset.AsQueryable();
        }
    }
}
