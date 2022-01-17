using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Entity.Models.Loans
{
    public class LoanViewModel : BaseEntityModel
    {
        public LoanViewModel() { }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "اجباری است")]
        public string Amount { get; set; }

        [Display(Name = "مبلغ وام")]
        [Required(ErrorMessage = "اجباری است")]
        public string LoanAmount { get; set; }


        [RegularExpression(@"^(?:100(?:\.00?)?|\d?\d(?:\.\d\d?)?)$", ErrorMessage = "{0} را صحیح وارد نمایید")]
        [Display(Name = "Percent")]
        [Required(ErrorMessage = "اجباری است")]
        public decimal Percent { get; set; }

        [Display(Name = "تعداد اقساط")]
        [Required(ErrorMessage = "اجباری است")]
        [MaxLength(2, ErrorMessage = "MaxLength")]
        [MinLength(1, ErrorMessage = "MinLength")]
        public int installmentCount { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime RegisterDate { get; set; }
        public string  RegisterDateStr { get; set; }
    }
}
