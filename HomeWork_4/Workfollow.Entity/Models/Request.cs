using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    public partial class Request : EntityBase
    {
        public Request()
        {
            Messagings = new HashSet<Messaging>();
        }

        public int RequestId { get; set; }
        public string RequestHeader { get; set; }
        public int DepartmentId { get; set; }
        public string RequestStatus { get; set; }
        public int JobListId { get; set; }
        public DateTime RequestJobStartDate { get; set; }
        public DateTime RequestJobEndDate { get; set; }
        public string RequestContent { get; set; }
        public int EmployeeId { get; set; }
        public int? FkEmployeeId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee FkEmployee { get; set; }
        public virtual JobList JobList { get; set; }
        public virtual ICollection<Messaging> Messagings { get; set; }
    }
}
