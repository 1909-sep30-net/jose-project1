using System;
using System.Collections.Generic;


namespace Old_Record_Store.Library
{
    public class Orders
    {

        public int OrderId { get; set; }
        public static DateTime Date { get; set; }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }


        //                            Customer customer
        public static void PlaceOrder(string name, Location store, List<Records> record, int amount)
        {
   
        }
    }
}
