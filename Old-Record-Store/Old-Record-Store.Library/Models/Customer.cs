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

        //Creates a customer object and fills the fields according to the name specified, generates an ID with cannot be changed. 
        //public static void AddCustomer(string fullname, string phone, string address, string email)
        //{
        //    Customer cust = new Customer();
        //    Random custID =  new Random();

        //    cust.FullName = fullname;
        //    cust.Phone = phone;
        //    cust.Address = address;
        //    cust.Email = email;
        //   // cust.CustomerID = custID.Next().ToString();

        //    Console.WriteLine("Customer: " + cust.FullName + " successfully added, you can now place orders!" + " ID: " + cust.CustomerID);
        //    Console.WriteLine("Please do not forget to write your unique ID");

        //    CustomerList.Add(cust); 
        //}

        //Prints out the list of customers, does not display ID.
        public static void DisplayCustomers()
        {
            foreach(Customer cust in CustomerList)
            {
                Console.WriteLine("Full Name: " + cust.FullName + " Phone: " + cust.Phone + " Address: " +cust.Address + " Email: " + cust.Email);
            }
        }

        //Utilizes a field to look up a customer, iterates through customer list and checks if it is there
        public void SeachCustomer(string field)
        {

        }
    }
}
