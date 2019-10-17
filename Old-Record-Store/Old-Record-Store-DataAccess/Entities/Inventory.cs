using System;
using System.Collections.Generic;

namespace Old_Record_Store_DataAccess.Entities
{
    public partial class Inventory
    {
        public int Stock { get; set; }
        public int RecordId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Records Record { get; set; }
    }
}
