using System;
using System.Collections.Generic;
using System.Text;

namespace Old_Record_Store.Library
{
    public class Records
    {
        static List<Records> inventory = new List<Records>();

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public string ReleaseDate { get; set; }
        public int RecordId { get; set; }
        public decimal Price { get; set; }

        //public static bool CheckStock(string recordToFind)
        //{ 
        //    foreach(Records record in inventory)
        //    {
        //        if (record.Name.Equals(recordToFind) && record.Stock > 0)
        //        {
        //            Console.WriteLine(record.Stock);
        //            return true;
        //        }
        //    }
        //    Console.WriteLine("Not enough stock for order");
        //    return false;
        //}

    }
}
