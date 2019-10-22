using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            Inventory = new HashSet<InventoryViewModel>();
            Orders = new HashSet<OrderViewModel>();
        }

        public string Name { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<InventoryViewModel> Inventory { get; set; }
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
