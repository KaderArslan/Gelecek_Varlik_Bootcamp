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
    public class RequestManager : GenericManager<Request, DtoRequest>, IRequestService
    {
        public readonly IRequestRepository requestRepository;

        public RequestManager(IServiceProvider service) : base(service) //al sen bunu ust sinifa gonder
        {
            requestRepository = service.GetService<IRequestRepository>();
        }

        IResponse<IQueryable<DtoAddRequest>> IRequestService.GetTotalReport()
        {
            try
            {
                var list = requestRepository.GetTotalReport();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoAddRequest>(x));
                //bir datayı cektigimde ve select uyguladigimda zaten queryable olarak gelir
                return new Response<IQueryable<DtoAddRequest>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<DtoAddRequest>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<DtoAddRequest> Add(DtoAddRequest item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Request>(item);

                var result = requestRepository.Add(model);

                if (saveChanges)
                    Save();

                return new Response<DtoAddRequest>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Request, DtoAddRequest>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoAddRequest>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
