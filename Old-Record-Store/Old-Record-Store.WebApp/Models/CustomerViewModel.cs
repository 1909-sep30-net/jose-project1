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
        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[a-z -']+$",
                            ErrorMessage = "Make sure your name does not have numbers or special characters ")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Make sure your email follows the format email@domain.com")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?:\(?)(?<AreaCode>\d{3})(?:[\).\s]?)(?<Prefix>\d{3})(?:[-\.\s]?)(?<Suffix>\d{4})(?!\d)+$",
                            ErrorMessage = "Make sure your phone is 8 digits and has no special characters or letters")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
