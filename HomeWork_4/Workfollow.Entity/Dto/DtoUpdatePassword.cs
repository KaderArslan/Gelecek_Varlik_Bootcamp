using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    //amac empleyee cekmek
    public class DtoUpdatePassword : DtoBase
    {

        //public DtoLoginEmployee()
        //{

        //}
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Kullanıcı soyadı boş bırakılamaz.")]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Text)]
        public string EmployeeSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı emaili boş bırakılamaz.")]
        [StringLength(maximumLength: 30)]
        [DataType(DataType.Text)]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Kullanıcı parolası boş bırakılamaz.")]
        [StringLength(maximumLength: 6)]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }


    }
}
