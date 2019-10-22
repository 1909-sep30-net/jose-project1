using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormCustomerSearch
    {
        [Display(Name = "Please Input the Customer's Full Name: ")]
        public string FullName { get; set; }
    }
}
