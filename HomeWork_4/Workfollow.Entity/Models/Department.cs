using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    //partial buyuk bir classi parcalamak icin kullanilir
    public partial class Department : EntityBase
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Requests = new HashSet<Request>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int JobListId { get; set; }

        public virtual JobList JobList { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
