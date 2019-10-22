using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
        }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Customer I.D")]
        public int CustomerId { get; set; }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
