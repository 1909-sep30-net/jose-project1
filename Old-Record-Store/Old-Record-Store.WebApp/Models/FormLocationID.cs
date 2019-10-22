using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormLocationID
    {
        [Display(Name = "Please Input a Location ID to look-up the order history")]
        public int LocationID { get; set; }
    }
}
