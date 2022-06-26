using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoMessaging : DtoBase
    {
        public int MessagingId { get; set; }
        public string MessagingText { get; set; }
        public int EmployeeId { get; set; }
        public int FkEmployeeId { get; set; }
        public int RequestId { get; set; }

    }
}
