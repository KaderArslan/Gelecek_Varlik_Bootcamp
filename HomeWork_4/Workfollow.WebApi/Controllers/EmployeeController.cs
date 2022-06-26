using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Workfollow.Entity.Base;
using Workfollow.Entity.Dto;
using Workfollow.Entity.IBase;
using Workfollow.Entity.Models;
using Workfollow.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workfollow.WebApi.Base;
using Microsoft.AspNetCore.Authorization;

namespace Workfollow.WebApi.Controllers
{
    //[Route("api/personel")] bunun altindaki her action bu sekilde erisilir

    [Route("api/[controller]")]
    [ApiController]
    //Microsoftun kendi base ControllerBase o yuzden bizimkini almasi icin
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //login metodu yazacagim
        [HttpPost("Login")]
        //[AllowAnonymous]//bu metodu tokendan hariç tut token olmadanda bu metodta işlem yap demektir
        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            try
            {
                return employeeService.Login(login);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Error" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null

                };
            }
        }

        [HttpPost("EmployeeRegiser")]
        [AllowAnonymous]
        public IResponse<DtoEmployeeRegister> Add(DtoEmployeeRegister entity)
        {

            try
            {
                return employeeService.Add(entity);//entityi kaydet
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployeeRegister>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPut("UpdatePassword")]
        public IResponse<DtoUpdatePassword> Update(DtoUpdatePassword entity)
        {
            try
            {
                return employeeService.Update(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoUpdatePassword>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
