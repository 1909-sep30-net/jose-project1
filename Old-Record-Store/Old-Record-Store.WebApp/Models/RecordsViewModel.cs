using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class RecordsViewModel
    {
        public RecordsViewModel()
        {
            Inventory = new HashSet<InventoryViewModel>();
            OrderHistory = new HashSet<OrderHistoryViewModel>();
        }

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public string ReleaseDate { get; set; }
        public int RecordId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<InventoryViewModel> Inventory { get; set; }
        public virtual ICollection<OrderHistoryViewModel> OrderHistory { get; set; }
    }
}
