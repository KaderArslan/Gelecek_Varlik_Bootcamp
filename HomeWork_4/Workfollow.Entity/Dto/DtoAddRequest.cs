using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;
using Workfollow.Entity.Models;

namespace Workfollow.Entity.Dto
{
    public class DtoAddRequest : DtoBase
    {

        [Required(ErrorMessage = "Talep Başlığı Boş Bırakılamaz!")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string RequestHeader { get; set; }

        [Required(ErrorMessage = "Departman ID Boş Bırakılamaz, 1:Frontend, 2:Backend, 3:Full Stack")]
        [StringLength(maximumLength: 50)]
        //public int DepartmentId { get; set; }
        public DtoDepartment DtoDepartment { get; set; }

        [Required(ErrorMessage = "Öncelik Durumu Boş Bırakılamaz! (Kritik, Acil, vb...)")]
        [StringLength(maximumLength: 10)]
        [DataType(DataType.Text)]
        public string RequestStatus { get; set; }

        //public JobList JobList { get; set; }
        [Required(ErrorMessage = "İş Listesi")]
        public DtoJobList DtoJobList { get; set; }

        [Required(ErrorMessage = "İşin Başlangıç Tarihi Boş Bırakılamaz")]
        [DataType(DataType.Date)]
        public DateTime RequestJobStartDate { get; set; }
        [Required(ErrorMessage = "İşin Bitiş Tarihi Boş Bırakılamaz")]
        [DataType(DataType.Date)]
        public DateTime RequestJobEndDate { get; set; }

        [Required(ErrorMessage = "Talep İçerik Bilgisi Boş Bırakılamaz")]
        [StringLength(maximumLength: 150)]
        [DataType(DataType.Text)]
        public string RequestContent { get; set; }

        //public int EmployeeId { get; set; }
        //public int? FkEmployeeId { get; set; }

    }
}
