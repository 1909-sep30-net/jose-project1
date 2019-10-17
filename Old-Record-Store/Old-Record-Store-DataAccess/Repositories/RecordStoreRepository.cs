using Old_Record_Store.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Old_Record_Store_DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Old_Record_Store_DataAccess.Repositories
{
    public class RecordStoreRepository : IRecordStoreRepository
    {
        public RecordStoreContext _dbcontext;
        public RecordStoreRepository(RecordStoreContext RecordContext) =>
                                 _dbcontext = RecordContext;

        public void AddCustomer(Old_Record_Store.Library.Customer customer)
        {
            var mappedCustomer = Mapper.MapEntityWithCustomer(customer);
            _dbcontext.Customer.Add(mappedCustomer);
            _dbcontext.SaveChanges();
        }

        public void AddToOrder(int customerID,int locationID, List<int> recordID, List<int> amounts)
        {
            //Create an order object with record id and location id ^
            Old_Record_Store.Library.Orders newOrder = new Old_Record_Store.Library.Orders
            {
                LocationId = locationID,
                CustomerId = customerID,
            };

            var mappedOrder = Mapper.MapEntityWithOrder(newOrder);
            
            _dbcontext.Orders.Add(mappedOrder);
            _dbcontext.SaveChanges();
           
                foreach (var i in recordID)
                {
                    Old_Record_Store.Library.OrderHistory customerOrder = new Old_Record_Store.Library.OrderHistory
                    {
                        RecordId = recordID.ElementAt(0),
                        OrderId = mappedOrder.OrderId,
                        RecordAmount = amounts.ElementAt(0)
                    };
                    
                    var mappedOrderHistory = Mapper.MapEntityWithOrderHistory(customerOrder);
                    //int updatedStock =
                    // _dbcontext.Inventory.Update(_dbcontext.Inventory.Find(_dbcontext.Inventory.Find(mappedOrderHistory.RecordId, locationID).Stock = _dbcontext.Inventory.Find(mappedOrderHistory.RecordId, locationID).Stock - customerOrder.RecordAmount);
                    //update the stock -> _dbcontext.inventory.Update(mappedHistory.RecordID, locationID).stock
                    var InventoryToModify = _dbcontext.Inventory.Find(mappedOrderHistory.RecordId, locationID);
                    Console.WriteLine(_dbcontext.Inventory.Find(mappedOrderHistory.RecordId, locationID).Stock);
                    InventoryToModify.Stock = InventoryToModify.Stock - customerOrder.RecordAmount;
                    _dbcontext.SaveChanges();
                    //make sure its entity object, gotta map maybe
                    var mappedCustomerOrder = Mapper.MapEntityWithOrderHistory(customerOrder);
                    _dbcontext.OrderHistory.Add(mappedCustomerOrder);
                    _dbcontext.SaveChanges();
                }
     
        }

        public void DisplayCustomers()
        { 
            var customerList = _dbcontext.Customer.ToList();
            foreach(Entities.Customer cust in customerList)
            {
                Console.WriteLine(cust.CustomerId + "                            " + cust.FullName);
            }

        }

        public void DisplayLocations()
        {
            var locationList = _dbcontext.Location.ToList();
            foreach(Entities.Location location in locationList)
            {
                Console.WriteLine(location.LocationId + "                              " + location.Name);
            }
        }

        public void DisplayOrderDetails(int orderID)
        {
            var OrderDetails = _dbcontext.Orders.Find(orderID);
            Console.WriteLine("Display details of Order #" + OrderDetails.OrderId
                    + "\nCustomer ID: " + OrderDetails.CustomerId + " Name: " + _dbcontext.Customer.Find(OrderDetails.CustomerId).FullName
                    + "\nLocation ID: " + OrderDetails.LocationId + " Location: " + _dbcontext.Location.Find(OrderDetails.LocationId).Name
                    + "\nDate: " + OrderDetails.Date);
        }

        public void DisplayOrderHistoryByCustomer(int customerID)
        {
            var OrderDetails = _dbcontext.Orders.Include(or => or.OrderHistory).Where(r => r.CustomerId == customerID).ToList();
            foreach (Entities.Orders or in OrderDetails)
            {
//                var recordId = _dbcontext.OrderHistory.Find(or.OrderId).RecordId;
                Console.WriteLine("Display order history of customer " + _dbcontext.Customer.Find(or.CustomerId).FullName + " With customer ID: " + or.CustomerId
                    + "\nOrder ID: " + or.OrderId + " Record ID: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordId + "Amount: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordAmount
                    + "\nRecord Name: " + _dbcontext.Records.Find(_dbcontext.OrderHistory.Find(or.OrderId).RecordId).Name
                    + "\nLocation ID: " + or.LocationId + " Location: " + _dbcontext.Location.Find(or.LocationId).Name
                    + "\nDate: " + or.Date
                    + "\n ----------------------------------------------------------------------------");
            }
        }

        public void DisplayOrderHistoryByLocation(int locationID)
        {
            var OrderDetails = _dbcontext.Orders.Include(or => or.Location).Where(r => r.LocationId == locationID).ToList();
            foreach (Entities.Orders or in OrderDetails)
            {
                var recordId = _dbcontext.OrderHistory.Find(or.OrderId).RecordId;
                Console.WriteLine("Display Order History from Location: " + or.Location.Name
                    + "\nOrder ID: " + or.OrderId + " Record ID: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordId + "Amount: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordAmount
                    + "\nRecord Name: " + _dbcontext.Records.Find(recordId).Name
                    + "\nDate: " + or.Date
                    + "\n ----------------------------------------------------------------------------") ;
            }
        }

        public void DisplayOrderList()
        {
            var orderList = _dbcontext.Orders.ToList();
            foreach(Entities.Orders order in orderList)
            {
                Console.WriteLine(order.OrderId);
            }
        }

        public void DisplayRecords(int locationID)
        {
            var recordList = _dbcontext.Records.ToList();
            foreach (Entities.Records record in recordList)
            {
                Console.WriteLine(record.RecordId + "            " + record.Name + " - " +  record.Artist + "  " + "($" + record.Price + ")" + "   " + _dbcontext.Inventory.Find(record.RecordId,locationID).Stock);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SeachCustomer(string field)
        {
            var customerList = _dbcontext.Customer.ToList();
            bool success = false;
            foreach (Entities.Customer cust in customerList)
            {
                if(cust.FullName == field)
                {
                    Console.WriteLine("Customer: " + cust.FullName + " found with Customer ID: " + cust.CustomerId);
                    success = true;
                }
            }
            if(!success)
            Console.WriteLine("Customer not found");
        }
    }
}
