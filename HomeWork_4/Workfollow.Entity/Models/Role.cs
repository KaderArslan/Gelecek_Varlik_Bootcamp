using System;
using System.Collections.Generic;
using Workfollow.Entity.Base;

#nullable disable

namespace Workfollow.Entity.Models
{
    public partial class Role : EntityBase
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
