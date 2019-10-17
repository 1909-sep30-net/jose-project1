using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Old_Record_Store_DataAccess
{
    public static class Mapper
    {
        public static Old_Record_Store.Library.Customer MapCustomerWithEntity (Entities.Customer customer)
        {
            return new Old_Record_Store.Library.Customer
            {
                FullName = customer.FullName,
                Email = customer.Email,
                Address = customer.Address,
                Phone = customer.Phone,
                CustomerID = customer.CustomerId
            };
        }

        public static Entities.Customer MapEntityWithCustomer(Old_Record_Store.Library.Customer customer)
        {
            return new Entities.Customer
            {
                FullName = customer.FullName,
                Email = customer.Email,
                Address = customer.Address,
                Phone = customer.Phone,
                CustomerId = customer.CustomerID
            };
        }

        public static Old_Record_Store.Library.Records MapRecordWithEntity(Entities.Records record)
        {
            return new Old_Record_Store.Library.Records
            {
                Name = record.Name,
                Artist = record.Artist,
                Label = record.Label,
                RecordId = record.RecordId,
                ReleaseDate = record.ReleaseDate,
                Price = record.Price
            };
        }

        public static Entities.Records MapEntityWithRecord(Old_Record_Store.Library.Records record)
        {
            return new Entities.Records
            {
                Name = record.Name,
                Artist = record.Artist,
                Label = record.Label,
                RecordId = record.RecordId,
                ReleaseDate = record.ReleaseDate,
                Price = record.Price
            };
        }

        public static Old_Record_Store.Library.Orders MapOrderWithEntity(Entities.Orders order)
        {
            return new Old_Record_Store.Library.Orders
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                OrderTotal = order.OrderTotal
            };
        }

        public static Entities.Orders MapEntityWithOrder(Old_Record_Store.Library.Orders order)
        {
            return new Entities.Orders
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                OrderTotal = order.OrderTotal
            };
        }
        public static Old_Record_Store.Library.OrderHistory MapOrderHistoryWithEntity(Entities.OrderHistory order)
        {
            return new Old_Record_Store.Library.OrderHistory
            {
                OrderId = order.OrderId,
                RecordId = order.RecordId,
                RecordAmount = order.RecordAmount
            };
        }
        public static Entities.OrderHistory MapEntityWithOrderHistory(Old_Record_Store.Library.OrderHistory order)
        {
            return new Entities.OrderHistory
            {
                OrderId = order.OrderId,
                RecordId = order.RecordId,
                RecordAmount = order.RecordAmount
            };
        }


    }
}
