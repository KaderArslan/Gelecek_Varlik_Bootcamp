using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    //partial buyuk bir classi parcalamak icin kullanilir
    //personel kimlik bilgileri ayri bir partial
    //is bilgileri ayri
    //ama kullanirken tum ozellikleri karsimiza cikar
    public partial class Employee : EntityBase
    {
        public Employee()
        {
            MessagingEmployees = new HashSet<Messaging>();
            MessagingFkEmployees = new HashSet<Messaging>();
            RequestEmployees = new HashSet<Request>();
            RequestFkEmployees = new HashSet<Request>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeTelNumber { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeePassword { get; set; }
        public int EmployeeRoleId { get; set; }
        public int? EmployeeRegisterId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsExecutive { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role EmployeeRole { get; set; }
        public virtual ICollection<Messaging> MessagingEmployees { get; set; }
        public virtual ICollection<Messaging> MessagingFkEmployees { get; set; }
        public virtual ICollection<Request> RequestEmployees { get; set; }
        public virtual ICollection<Request> RequestFkEmployees { get; set; }
    }
}
