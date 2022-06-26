using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Dal.Abstract;
using Workfollow.Dal.Concrete.Entityframework.Context;
using Workfollow.Entity.Base;
using Workfollow.Entity.Dto;
using Workfollow.Entity.IBase;
using Workfollow.Entity.Models;
using Workfollow.Interface;


namespace Workfollow.Bll
{
    public class EmployeeManager : GenericManager<Employee, DtoEmployee>, IEmployeeService
    {
        //Dal'la haberlesmiyor
        //IEmployeeRepository i dahil edecegiz
        public readonly IEmployeeRepository employeeRepository;
        private IConfiguration configuration;

        public EmployeeManager(IServiceProvider service, IConfiguration configuration) : base(service) //al sen bunu ust sinifa gonder
        {
            employeeRepository = service.GetService<IEmployeeRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoEmployeeRegister> Add(DtoEmployeeRegister item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Employee>(item);

                var result = employeeRepository.Add(model); //donustu kaydetme yapacagiz artik

                if (saveChanges)
                    Save();

                return new Response<DtoEmployeeRegister>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Employee, DtoEmployeeRegister>(result)//T tipinde result
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployeeRegister>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }

        //token olusturma kontrol islemleri hep burda olacak 
        //DtoLogin bunda email ve parola tek var ya da yetki
        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            //Employee ye donusturecegiz neyi login datasini
            var employee = employeeRepository.Login(ObjectMapper.Mapper.Map<Employee>(login));
            //employee ya bilgi gelecek ya da null gelecek
            if(employee != null)//veri yani employee vardir
            {
                //employee var ise token uretmem gerekiyor, Bllîn altina yazdim metodunu TokenManager
                //TokenManageri ilgili parametreyi gonderecem, benim icin token uretecek ve buraya gonderecek
                //response geri donecek

                //DtoLoginEmployee donustur
                var dtoEmployee = ObjectMapper.Mapper.Map<DtoLoginEmployee>(employee);
                //token tokenmanagerdan gelecek
                //token managera ben dtoEmploye yi gonderecem o ilgili tokeni uretip bana gonderecek
                //token oluşturuldu
                var token = new TokenManager(configuration).CreateAccessToken(dtoEmployee);

                var employeeToken = new DtoEmployeeToken()
                {
                    DtoLoginEmployee = dtoEmployee,
                    //oluşturulan token access tokene verildi
                    AccessToken = token 
                };
                return new Response<DtoEmployeeToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = employeeToken
                };
            }
            else
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Kullanıcı maili ya da parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }

        public IResponse<DtoUpdatePassword> Update(DtoUpdatePassword item, bool saveChanges = true)
        {
            try
            {
                var model = ObjectMapper.Mapper.Map<Employee>(item);

                var result = employeeRepository.Update(model);

                if (saveChanges)
                    Save();

                return new Response<DtoUpdatePassword>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Success",
                    Data = ObjectMapper.Mapper.Map<Employee, DtoUpdatePassword>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoUpdatePassword>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
