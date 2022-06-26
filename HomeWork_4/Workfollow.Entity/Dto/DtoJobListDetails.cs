using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoJobListDetails : DtoBase
    {
        //public DtoJobListDetails()
        //{
        //}

        public int JobListId { get; set; }
        public string JobListName { get; set; }
        public DtoRequest DtoRequest { get; set; }

        public DtoMessaging DtoMessaging { get; set; }
        public DtoDepartment DtoDepartment { get; set; }


    }
}
