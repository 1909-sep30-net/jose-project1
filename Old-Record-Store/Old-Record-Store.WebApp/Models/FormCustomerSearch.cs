using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormCustomerSearch
    {

        [Required]
        [Display(Name = "Please Input the Customer's Full Name: ")]
        [RegularExpression(@"^[a-z -']+$",
                            ErrorMessage = "Make sure the customer name search is valid (no special characters) ")]
        public string FullName { get; set; }
    }
}
