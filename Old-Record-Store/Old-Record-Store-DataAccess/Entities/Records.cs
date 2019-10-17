using System;
using System.Collections.Generic;

namespace Old_Record_Store_DataAccess.Entities
{
    public partial class Records
    {
        public Records()
        {
            Inventory = new HashSet<Inventory>();
            OrderHistory = new HashSet<OrderHistory>();
        }

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public string ReleaseDate { get; set; }
        public int RecordId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
