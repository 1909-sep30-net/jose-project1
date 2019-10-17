using System;
using System.Collections.Generic;
using System.Text;

namespace Old_Record_Store.Library
{
    //has an inventory
    //inventory decreases when orders are accepted
    //rejects orders that cannot be fulfilled with remaining inventory
    //(optional: more than one inventory item decrements for a given product order, for at least one product)
    public class Location
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public static List<Records> Inventory { get; set; }
        public Orders Orders { get; set; }
        static public List<Location> Locations = new List<Location>();
   

        public static void UpdateStock(string recordname, int amount, string locationname)
        {
            foreach (Records record in Inventory)
            {
                if (record.Name.Equals(recordname) && Location.CheckStock(recordname))
                {
                   // record.Stock = record.Stock - amount;
                }
                else
                {
                    Console.WriteLine("Cannot update stock");
                    break;
                }
            }
        }

        public static bool SearchLocation (string Name)
        {
            foreach (Location loc in Locations)
            {
                if (Name.Equals(loc.Name))
                {
                    Console.WriteLine("Location found");
                    return true;
                }
            }
            return false;
        }
        public static bool CheckStock(string recordToFind)
        {
            //foreach (Records record in Inventory)
            //{
            //    if (record.Name.Equals(recordToFind) && record.Stock > 0)
            //    {
            //       // Console.WriteLine(record.Stock);
            //        return true;
            //    }
            //}
            //Console.WriteLine("Not enough stock for order");
            return false;
        }
        public static void DisplayLocations()
        {
            foreach (Location loc in Locations)
            {
                Console.WriteLine("Full Name: " + loc.Name);
            }
        }
        public static void AddToOrder(string recordname)
        {

        }
    }
}
