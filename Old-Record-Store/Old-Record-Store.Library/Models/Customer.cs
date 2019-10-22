using System;
using System.Collections.Generic;
using System.Text;


namespace Old_Record_Store.Library
{
    public class Customer
    {
     
        static List<Customer> CustomerList = new List<Customer>();

        //Auto-properties for customer fields
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }

    }
}
