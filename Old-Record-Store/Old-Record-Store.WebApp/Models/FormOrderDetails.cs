using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormOrderDetails
    {
        [Display(Name = "Please Input the Order ID you wish to see the details for: ")]
        public int OrderID { get; set; }
    }
}
