using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class FormInventoryLocationID
    {
        [Display(Name = "Please Input the Location ID to look up the inventory")]
        public int LocationID { get; set; }
    }
}
