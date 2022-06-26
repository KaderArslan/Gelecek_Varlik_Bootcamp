using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoRole : DtoBase
    {
        public DtoRole()
        {
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
