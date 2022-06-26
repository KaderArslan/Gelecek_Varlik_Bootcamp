using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoLoginEmployee : DtoBase
    {
        //tokena gommeden ek bilgi olarak geri gonderme
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeTelNumber { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsExecutive { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeRoleId { get; set; }
        public int? EmployeeRegisterId { get; set; }
    }
}
