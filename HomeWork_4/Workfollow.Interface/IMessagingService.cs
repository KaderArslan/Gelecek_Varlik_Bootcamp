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
    public interface IMessagingService : IGenericService<Messaging, DtoMessaging>
    {
        IResponse<IQueryable<DtoMessaging>> GetTotalReport();
    }
}
