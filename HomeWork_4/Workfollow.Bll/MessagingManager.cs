using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Entity.Base;
using Workfollow.Entity.Dto;
using Workfollow.Entity.IBase;
using Workfollow.Entity.Models;
using Workfollow.Interface;

namespace Workfollow.Bll
{
    public class MessagingManager : GenericManager<Messaging, DtoMessaging>, IMessagingService
    {
        public readonly IMessagingRepository messagingRepository;

        public MessagingManager(IServiceProvider service) : base(service) //al sen bunu ust sinifa gonder
        {
            messagingRepository = service.GetService<IMessagingRepository>();
        }
        public IResponse<IQueryable<DtoMessaging>> GetTotalReport()
        {
            try
            {
                var list = messagingRepository.GetTotalReport();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessaging>(x));
                //bir datayı cektigimde ve select uyguladigimda zaten queryable olarak gelir
                return new Response<IQueryable<DtoMessaging>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<DtoMessaging>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
