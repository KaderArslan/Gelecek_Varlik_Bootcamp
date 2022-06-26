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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Role> GetTotalReport()
        {
            return dbset.AsQueryable();
        }
    }
}
