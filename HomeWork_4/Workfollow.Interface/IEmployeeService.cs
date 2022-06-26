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
    public interface IEmployeeService : IGenericService<Employee, DtoEmployee>
    {
        //ozel metodlari burada yapacagiz
        //List<DtoEmployee> GetListAll();
        IResponse<DtoEmployeeToken> Login(DtoLogin login);

        IResponse<DtoEmployeeRegister> Add(DtoEmployeeRegister item, bool saveChanges = true);

        IResponse<DtoUpdatePassword> Update(DtoUpdatePassword item, bool saveChanges = true);
    }
}
