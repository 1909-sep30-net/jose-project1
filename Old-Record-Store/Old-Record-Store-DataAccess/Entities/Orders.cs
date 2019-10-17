using System;
using System.Collections.Generic;

namespace Old_Record_Store_DataAccess.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
