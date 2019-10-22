using Old_Record_Store.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Old_Record_Store_DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;

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
        /*
         * Separate Add To Order into separate methods
         * 1) Creates New Order with Location ID and Customer ID and map accordingly, Add to DB and Save Changes
         * 2) Create new Order History with Record ID (from form selection, Order ID (from Order created ^), Record Amount from form selection), add and Save changes
         * 3) Update Inventory (using OrderHistory.RecordID and Location ID from form selection) - recordAmount(0) from OrderHistory
         * 4) Map order history and save changes.
         */
        public Old_Record_Store.Library.OrderHistory AddToOrder(int customerID, int locationID, int recordID, int amounts)
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


            Old_Record_Store.Library.OrderHistory customerOrder = new Old_Record_Store.Library.OrderHistory
            {
                RecordId = recordID,
                OrderId = mappedOrder.OrderId,
                RecordAmount = amounts
            };

            newOrder.OrderTotal = customerOrder.RecordAmount * _dbcontext.Records.Where(x => x.RecordId == customerOrder.RecordId).Count();

            var mappedOrderHistory = Mapper.MapEntityWithOrderHistory(customerOrder);
            var InventoryToModify = _dbcontext.Inventory.Find(mappedOrderHistory.RecordId, locationID);
            InventoryToModify.Stock = InventoryToModify.Stock - customerOrder.RecordAmount;
            _dbcontext.SaveChanges();
            var mappedCustomerOrder = Mapper.MapEntityWithOrderHistory(customerOrder);
            _dbcontext.OrderHistory.Add(mappedCustomerOrder);
            _dbcontext.SaveChanges();
            return customerOrder;

        }

        public List<Old_Record_Store.Library.Customer> DisplayCustomers()
        { 
            var customerList = _dbcontext.Customer.ToList();
            var mappedCustList = new List<Old_Record_Store.Library.Customer>();
            
            foreach(Entities.Customer cust in customerList)
            { 
                mappedCustList.Add(Mapper.MapCustomerWithEntity(cust));
            }

            return mappedCustList;
        }

        public List<Old_Record_Store.Library.Location> DisplayLocations()
        {
            var dbLocationList = _dbcontext.Location.Include(i => i.Inventory);
            var locationList = new List<Old_Record_Store.Library.Location>();
            foreach(Entities.Location location in dbLocationList)
            {
                locationList.Add(new Old_Record_Store.Library.Location()
                {
                    LocationId = location.LocationId,
                    Name = location.Name,
                    Inventory = location.Inventory.Select(i => new Old_Record_Store.Library.Inventory
                    { 
                        RecordId = i.RecordId,
                        LocationId = i.LocationId,
                        Stock = i.Stock
                     
                    }).ToHashSet()
                });
            }
            return locationList;
        }
        public Old_Record_Store.Library.OrderHistory DisplayOrderHistoryDetails(int orderID)
        {
            try
            {
                var orderhistorydetails = _dbcontext.OrderHistory.Find(orderID);
                return Mapper.MapOrderHistoryWithEntity(orderhistorydetails);
            }
            catch (System.NullReferenceException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Argument null exception! Careful", ex);
                Console.WriteLine("done");
                return null;
            }
        }
        public Old_Record_Store.Library.Orders DisplayOrderDetails(int orderID)
        {
            try
            {
                var OrderDetails = _dbcontext.Orders.Find(orderID);         
                return Mapper.MapOrderWithEntity(OrderDetails);

                //Console.WriteLine("Display details of Order #" + OrderDetails.OrderId
                //        + "\nCustomer ID: " + OrderDetails.CustomerId + " Name: " + _dbcontext.Customer.Find(OrderDetails.CustomerId).FullName
                //        + "\nLocation ID: " + OrderDetails.LocationId + " Location: " + _dbcontext.Location.Find(OrderDetails.LocationId).Name
                //        + "\nDate: " + OrderDetails.Date);

            }
            catch (System.NullReferenceException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Argument null exception! Careful", ex);
                Console.WriteLine("done");
                return null;
            }
        }

        public List<Old_Record_Store.Library.Orders> DisplayOrderHistoryByCustomer(int customerID)
        {
            try
            {
                var OrderDetails = _dbcontext.Orders.Include(or => or.OrderHistory).Where(r => r.CustomerId == customerID).ToList();
                List<Old_Record_Store.Library.Orders> LibraryOrderDetails = new List<Old_Record_Store.Library.Orders>();
                foreach (Entities.Orders or in OrderDetails)
                {
                    LibraryOrderDetails.Add(Mapper.MapOrderWithEntity(or));
                    //var recordId = _dbcontext.OrderHistory.Find(or.OrderId).RecordId;
                    ////                var recordId = _dbcontext.OrderHistory.Find(or.OrderId).RecordId;
                    //Console.WriteLine("Display order history of customer " + _dbcontext.Customer.Find(or.CustomerId).FullName + " With customer ID: " + or.CustomerId
                    //    + "\nOrder ID: " + or.OrderId + " Record ID: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordId + "Amount: " + _dbcontext.OrderHistory.Find(or.OrderId).RecordAmount
                    //    + "\nRecord Name: " + _dbcontext.Records.Find(_dbcontext.OrderHistory.Find(or.OrderId).RecordId).Name
                    //    + "\nLocation ID: " + or.LocationId + " Location: " + _dbcontext.Location.Find(or.LocationId).Name
                    //    + "\nDate: " + or.Date
                    //    + "\n ----------------------------------------------------------------------------");
                }
                return LibraryOrderDetails;
            }
            catch(System.NullReferenceException ex)
            {
                Console.WriteLine("done");
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Argument Null Exception! Careful", ex);
                return null;
            }
        }

        public List<Old_Record_Store.Library.Orders> DisplayOrderHistoryByLocation(int locationID)
        {
            try
            {
                var OrderDetails = _dbcontext.Orders.Include(or => or.Location).Where(r => r.LocationId == locationID).ToList();
                List<Old_Record_Store.Library.Orders> LibraryOrderDetails = new List<Old_Record_Store.Library.Orders>();
                foreach (Entities.Orders or in OrderDetails)
                {
                    LibraryOrderDetails.Add(Mapper.MapOrderWithEntity(or));
                }
                return LibraryOrderDetails;
            }
            catch (System.NullReferenceException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Argument Null Exception! Careful", ex);
                return null;
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
            int i = 1;
            
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public Old_Record_Store.Library.Customer SeachCustomer(string field)
        {
            //var customerList = _dbcontext.Customer.Find(field);
            var customerList = _dbcontext.Customer.ToList();
            foreach(var cust in customerList)
            {
                if (cust.FullName.Equals(field))
                    return Mapper.MapCustomerWithEntity(cust);
            }
            return null;
        }

        public List<Old_Record_Store.Library.Inventory> DisplayInventoryFromLocation(int locID)
        {
            var dbinventory = _dbcontext.Inventory.Where(x => x.LocationId == locID);
            var inventory = new List<Old_Record_Store.Library.Inventory>();
            foreach (var item in dbinventory)
            {
                inventory.Add(new Old_Record_Store.Library.Inventory
                {
                    LocationId = item.LocationId,
                    RecordId = item.RecordId,
                    Stock = item.Stock
                });
            }
            return inventory;
        }
    }
}
