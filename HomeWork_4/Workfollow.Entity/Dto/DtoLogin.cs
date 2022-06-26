using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Entity.Base;

namespace Workfollow.Entity.Dto
{
    public class DtoLogin : DtoBase
    {
        //public DtoLoginEmployee()
        //{

        //}

        [Required(ErrorMessage = "Kullanıcı emaili boş bırakılamaz.")] //zorunlu
        [StringLength(maximumLength:30)]//uzunlugunu da belirtebilirsin
        [DataType(DataType.Text)]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz!")]
        [StringLength(maximumLength: 6)]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
        //bu parolayı alip sifrelicegiz, logine parametre gonderecegiz

    }
}
