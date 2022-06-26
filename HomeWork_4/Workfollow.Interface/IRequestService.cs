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
    public interface IRequestService : IGenericService<Request, DtoRequest>
    {
        IResponse<IQueryable<DtoAddRequest>> GetTotalReport();

        IResponse<DtoAddRequest> Add(DtoAddRequest item, bool saveChanges = true);

    }
}
