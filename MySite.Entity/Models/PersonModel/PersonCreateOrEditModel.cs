using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Entity.Models.PersonModel
{
   public class PersonCreateOrEditModel:BaseEntityModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage ="اجباری است")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string FName { get; set; }

        [Display(Name = "کدملی")]
        public string NationalCode { get; set; }
       
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
    }
}
