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
    //Microsoftun kendi base ControllerBase o yuzden bizimkini almasi icin
    public class DepartmentController : ApiBaseController<IDepartmentService, Department, DtoDepartment>
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            this.departmentService = departmentService;
        }

        //personel listeleme
        //[HttpGet("GetTotalReport")]//abc.com/api/employee/GetTotalReport
        //public IResponse<IQueryable<DtoDepartment>> GetTotalReport()
        //{
        //    try
        //    {
        //        return departmentService.GetTotalReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<IQueryable<DtoDepartment>>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error:{ex.Message}",
        //            Data = null
        //        };
        //    }
        //}

    }
}
