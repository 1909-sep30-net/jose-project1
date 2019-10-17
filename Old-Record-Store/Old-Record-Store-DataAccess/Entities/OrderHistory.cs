using System;
using System.Collections.Generic;

namespace Old_Record_Store_DataAccess.Entities
{
    public partial class OrderHistory
    {
        public int OrderRecordId { get; set; }
        public int RecordAmount { get; set; }
        public int RecordId { get; set; }
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Records Record { get; set; }
    }
}
