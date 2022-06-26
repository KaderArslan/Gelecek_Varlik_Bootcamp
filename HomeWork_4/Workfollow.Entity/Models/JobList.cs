using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    public partial class JobList : EntityBase
    {
        public JobList()
        {
            Departments = new HashSet<Department>();
            Requests = new HashSet<Request>();
        }

        public int JobListId { get; set; }
        public string JobListName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
