using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoEmployeeRegister : DtoBase
    {
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

        public string EmployeeTelNumber { get; set; }

        [Required(ErrorMessage = "Department; Frontend:1, Backend:2, Full Stak:3")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Kullanıcı parolası boş bırakılamaz.")]
        [StringLength(maximumLength: 6)]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }

        //[Required(ErrorMessage = "Role; Admin:1, Yönetici:2, Personel:3")]
        //public int EmployeeRoleId { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public bool IsExecutive { get; set; }

        //public int? EmployeeRegisterId { get; set; }


    }
}
