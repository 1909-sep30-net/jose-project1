using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Old_Record_Store.WebApp.Models
{
    public class OrderHistoryViewModel
    {
        public int OrderRecordId { get; set; }
        [Display(Name = "Amount of Records purchased")]
        public int RecordAmount { get; set; }
        [Display(Name = "Record I.D")]
        public int RecordId { get; set; }
        [Display(Name = "Order I.D")]
        public int OrderId { get; set; }

        //public virtual OrderViewModel Order { get; set; }
        //public virtual RecordsViewModel Record { get; set; }
    }
}
