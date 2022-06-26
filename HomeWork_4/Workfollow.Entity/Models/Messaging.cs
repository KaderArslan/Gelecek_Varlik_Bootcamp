using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    public partial class Messaging : EntityBase
    {
        public int MessagingId { get; set; }
        public string MessagingText { get; set; }
        public int EmployeeId { get; set; }
        public int FkEmployeeId { get; set; }
        public int RequestId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee FkEmployee { get; set; }
        public virtual Request Request { get; set; }
    }
}
