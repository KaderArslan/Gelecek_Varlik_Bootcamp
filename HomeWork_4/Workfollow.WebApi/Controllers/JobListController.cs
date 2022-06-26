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
    public class JobListController : ApiBaseController<IJobListService, JobList, DtoJobList>
    {

        private readonly IJobListService joblistService;

        public JobListController(IJobListService joblistService) : base(joblistService)
        {
            this.joblistService = joblistService;
        }

        [HttpGet("JobListDetails")]
        public IResponse<IQueryable<DtoJobListDetails>> GetTotalReport()
        {
            try
            {
                return joblistService.GetTotalReport();
            }
            catch (Exception ex)
            {
                return new Response<IQueryable<DtoJobListDetails>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
