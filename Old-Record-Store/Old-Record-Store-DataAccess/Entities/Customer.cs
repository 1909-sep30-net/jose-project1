using System;
using System.Collections.Generic;

namespace Old_Record_Store_DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
