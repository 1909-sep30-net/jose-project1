using System;
using System.Collections.Generic;
using System.Text;

namespace Old_Record_Store.Library
{
    public interface IRecordStoreRepository : IDisposable
    {

        //Customer Methods
        void AddCustomer(Customer customer);

        //Prints out the list of customers, does not display ID.
        void DisplayCustomers();

        //Utilizes a field to look up a customer, iterates through customer list and checks if it is there
        void SeachCustomer(string field);

        //Location Methods
        void DisplayOrderHistoryByCustomer(int customerID);

        void DisplayOrderHistoryByLocation(int locationID);

        void AddToOrder(int customerID, int locationID, List<int> recordID, List<int> amounts);
        //Inventory
        void DisplayLocations();
        //OrderHistory
        void DisplayRecords(int locationID);
        void DisplayOrderDetails(int OrderID);
        void DisplayOrderList();
        void Save();

    }
}





