using Old_Record_Store.Library;
using System;
using Xunit;


namespace StoreTests
{
    public class Program
    {
        //Customer.AddCustomer("111", "111", "111", "111");
        //Customer.AddCustomer("222", "222", "222", "222");
        //Customer.DisplayCustomers();
        //Customer.SeachCustomer("111");

        //Customer cust1 = new Customer();
        //Location location1 = new Location();
        //List<Records> recordlist = new List<Records>();
        //Records record = new Records();

        //record.Name = "In The Court of The Crimson King";
        //record.Artist = "King Crimson";
        //record.ReleaseDate = "1970";
        //record.Stock = 22;
        //record.Format = "Vynil";

        //recordlist.Add(record);

        //cust1.FullName = "111";

        //Order.PlaceOrder(cust1, location1, recordlist, 1);

        [Fact]
        public void DisplayShouldDisplay()
        {
            //Arrange
            var c = new Customer();
            c.FullName = "111";

            //Act
            Customer.AddCustomer("111", "111", "111", "111");

            //Assert
            Assert.Equal("111", c.FullName);
        }
    }
}
