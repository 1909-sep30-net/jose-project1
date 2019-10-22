using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormPlaceOrder
    {
        [Required]
        [Display(Name = "Customer I.D")]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Location I.D")]
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "How many would you like to purchase?")]
        public int Amounts { get; set; }
        [Required]
        [Display(Name = "Record I.D")]
        public int RecordID { get; set; }
    }
}
