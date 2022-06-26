using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoJobList : DtoBase
    {
        public DtoJobList()
        {
        }

        public int JobListId { get; set; }
        public string JobListName { get; set; }

    }
}
