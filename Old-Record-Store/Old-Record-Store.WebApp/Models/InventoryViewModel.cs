using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class InventoryViewModel
    {
        public int Stock { get; set; }
        public int RecordId { get; set; }
        public int LocationId { get; set; }

        public virtual LocationViewModel Location { get; set; }
        public virtual RecordsViewModel Record { get; set; }
    }
}
