using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Dto;
using Workfollow.Entity.IBase;
using Workfollow.Entity.Models;

namespace Workfollow.Interface
{
    public interface IJobListService : IGenericService<JobList, DtoJobList>
    {
        IResponse<IQueryable<DtoJobListDetails>> GetTotalReport();
    }


}
