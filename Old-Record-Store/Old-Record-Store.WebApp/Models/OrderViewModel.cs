using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderHistory = new HashSet<OrderHistoryViewModel>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
        public virtual LocationViewModel Location { get; set; }
        public virtual ICollection<OrderHistoryViewModel> OrderHistory { get; set; }
    }
        
}
