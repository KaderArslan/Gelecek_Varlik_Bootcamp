using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    //kalitim vermemizin nedeni, dtobase ozellik eklersek kalitim vermis olalim diye
    public class DtoDepartment : DtoBase
    {
        public DtoDepartment()
        {
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int JobListId { get; set; }

    }
}
