using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Workfollow.Entity.Base;
using Workfollow.Entity.Dto;
using Workfollow.Entity.IBase;
using Workfollow.Entity.Models;
using Workfollow.Interface;
using Workfollow.WebApi.Base;

namespace Workfollow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpPost("AddRequest")] //HttpPost body ile data gonder diyoruz
        public IResponse<DtoAddRequest> Add(DtoAddRequest entity)
        {
            try
            {
                return requestService.Add(entity);//entityi kaydet
            }
            catch (Exception ex)
            {
                return new Response<DtoAddRequest>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("GetTotalReport")]
        public IResponse<IQueryable<DtoAddRequest>> GetTotalReport()
        {
            try
            {
                return requestService.GetTotalReport();
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

    }
}
