using System;
using System.Collections.Generic;
using System.Text;

namespace Old_Record_Store.Library
{
    public interface IRecordStoreRepository : IDisposable
    {

        //Customer Methods
        void AddCustomer(Customer customer);
        
        List<Inventory> DisplayInventoryFromLocation(int locID);

        //Prints out the list of customers, does not display ID.
        List<Customer> DisplayCustomers();

        //Utilizes a field to look up a customer, iterates through customer list and checks if it is there
        Customer SeachCustomer(string field);

        //Location Methods
        OrderHistory DisplayOrderHistoryDetails(int orderID);
        List<Orders> DisplayOrderHistoryByCustomer(int customerID);

        List<Orders> DisplayOrderHistoryByLocation(int locationID);

        OrderHistory AddToOrder(int customerID, int locationID, int recordID, int amounts);
        //Inventory
        List<Location> DisplayLocations();
        //OrderHistory
        void DisplayRecords(int locationID);
        Orders DisplayOrderDetails(int OrderID);
        void DisplayOrderList();
        void Save();

    }
}





