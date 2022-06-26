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
    public class DepartmentManager : GenericManager<Department, DtoDepartment>, IDepartmentService
    {
        public readonly IDepartmentRepository departmentRepository;

        public DepartmentManager(IServiceProvider service) : base(service) //al sen bunu ust sinifa gonder
        {
            departmentRepository = service.GetService<IDepartmentRepository>();
        }
        //public IResponse<IQueryable<DtoDepartment>> GetTotalReport()
        //{
        //    try
        //    {
        //        var list = departmentRepository.GetTotalReport();
        //        var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoDepartment>(x));
        //        //bir datayı cektigimde ve select uyguladigimda zaten queryable olarak gelir
        //        return new Response<IQueryable<DtoDepartment>>
        //        {
        //            StatusCode = StatusCodes.Status200OK,
        //            Message = "Success",
        //            Data = listDto
        //        };
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
