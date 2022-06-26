using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Models;

namespace Workfollow.Dal.Abstract
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetTotalReport();
    }
}
