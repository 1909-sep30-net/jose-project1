using System;
using Old_Record_Store.Library;
using System.Collections.Generic;
using Old_Record_Store_DataAccess;
using System.Linq;
using NLog;
using System.Text.RegularExpressions;

namespace Old_Record_Store.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int zero = 0;
                int result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("test divide by zero ex", ex);
                Console.WriteLine("Divide by zero exception handled, more details on the log file");
            }

            using IRecordStoreRepository recordStoreRepository = Dependencies.CreateRestaurantRepository();
            do
            {
                Console.WriteLine("Welcome to Record Store Application: ");
                Console.WriteLine("Please input a letter to interact with the menu, press 'e' to Exit the application");
                Console.WriteLine("\ta - Add Customer");
                Console.WriteLine("\tb - Display the Customer List");
                Console.WriteLine("\tc - Search for a Customer");
                Console.WriteLine("\td - Place an Order");
                Console.WriteLine("\te - Display Order Details");
                Console.WriteLine("\tf - Display Customer Order History");
                Console.WriteLine("\tg - Display Location Order History");
                Console.WriteLine("\th - Exit Software");
                string menuOption = Console.ReadLine();
                while (menuOption.Length > 1 || string.IsNullOrEmpty(menuOption))
                {
                    Console.WriteLine("Please input a valid menu item from the list (a, b, c, d, e, f, g, h)");
                    menuOption = Console.ReadLine();
                }
                switch (menuOption)
                {
                    case "a":

                        Console.WriteLine("Please input the customer's name: ");
                        string name = Console.ReadLine();
                        while (Regex.Match(name, "^[0-9]+$").Success||Regex.Match(name, @"^\W+$").Success || string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Please make sure the name does not have numbers, special characters, or is empty");
                            name = Console.ReadLine();
                        }

                        Console.WriteLine("Please input the customer's address: ");
                        string address = Console.ReadLine();
                        while (Regex.Match(address, @"^\W+$").Success || string.IsNullOrEmpty(address))
                        {
                            Console.WriteLine("Please make sure the name does not have numbers, special characters, or is empty");
                            name = Console.ReadLine();
                        }
                        Console.WriteLine("Please input the customer's phone: ");
                        string phone = Console.ReadLine();
                        while (Regex.Match(phone, @"^\d$").Success || Regex.Match(phone, @"^\W+$").Success || string.IsNullOrEmpty(phone))
                        {
                            Console.WriteLine("Please make sure the name does not have numbers, special characters, or is empty");
                            name = Console.ReadLine();
                        }
                        Console.WriteLine("Please input the customer's e-mail: ");
                        string email = Console.ReadLine();
                        while (Regex.Match(name, "^[0-9]+$").Success || Regex.Match(name, @"^\W+$").Success || string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Please make sure the name does not have numbers, special characters, or is empty");
                            name = Console.ReadLine();
                        }
                        Customer newCustomer = new Customer
                        {
                            FullName = name,
                            Address = address,
                            Phone = phone,
                            Email = email
                        };
                        recordStoreRepository.AddCustomer(newCustomer);
                        break;

                    case "b":
                        Console.WriteLine("Displaying current customer list");
                        Console.WriteLine("Customer ID                  Customer List");
                        Console.WriteLine("-----------                  --------------");
                        recordStoreRepository.DisplayCustomers();
                        break;

                    case "c":
                        Console.WriteLine("Please input a customer name to being search: ");
                        string field = Console.ReadLine();
                        recordStoreRepository.SeachCustomer(field);
                        break;

                    case "d":
                        List<int> recordList = new List<int>();
                        List<int> amountList = new List<int>();
                        bool selection = true;
                        Console.WriteLine("Please input a customer ID number to start the order: ");
                        Console.WriteLine("Customer ID                  Customer List");
                        Console.WriteLine("-----------                  --------------");

                        recordStoreRepository.DisplayCustomers();
                        int customerInput = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Please select a location to order from: ");
                        Console.WriteLine("Location ID                    Location List");
                        Console.WriteLine("-----------                    --------------");
                        recordStoreRepository.DisplayLocations();
                        int locationinput = Int32.Parse(Console.ReadLine());


                        Console.WriteLine("Please select the records ID you wish to add into your order, when done selecting records press '0' to proceed to the next window");
                        Console.WriteLine("Record ID        Name and Artist - (Price)");
                        Console.WriteLine("---------       -------------------------");
                        recordStoreRepository.DisplayRecords(locationinput);
                        while (selection)
                        {
                              Console.WriteLine("Please select the records ID you wish to add into your order, when done selecting records press '0' to proceed to the next window");
                            string customerSelection = Console.ReadLine();
                            if (customerSelection.Equals("0"))
                            {
                                selection = false;
                                break;
                            }

                            int parsedSelection = Int32.Parse(customerSelection);

                            recordList.Insert(0,(parsedSelection));
          
                            Console.WriteLine("added record ID: " + customerSelection + " to the list");
                                Console.WriteLine("Please input the amount of records you want to purchase: ");
                                int amountSelection = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Added " + amountSelection + " to the Shopping List");
                                amountList.Insert(0,amountSelection);
                            recordStoreRepository.AddToOrder(customerInput, locationinput, recordList, amountList);
                            //have to create an order then order history
                            //add record from location into order
                        }
                        recordStoreRepository.AddToOrder(customerInput, locationinput, recordList, amountList);
                        break;

                    case "e":
                        Console.WriteLine("Please input an order id from the following list to display the details: ");
                        recordStoreRepository.DisplayOrderList();
                        int recordID = Int32.Parse(Console.ReadLine());
                        recordStoreRepository.DisplayOrderDetails(recordID);
                        break;
                    case "f":
                        Console.WriteLine("Please input a customer id from the following customer list to display the order History: ");
                        recordStoreRepository.DisplayCustomers();
                        int customerID = Int32.Parse(Console.ReadLine());
                        recordStoreRepository.DisplayOrderHistoryByCustomer(customerID);
                        break;
                    case "g":
                        Console.WriteLine("Please input a location id from the following list to display the order History: ");
                        recordStoreRepository.DisplayLocations();
                        int locationID = Int32.Parse(Console.ReadLine());
                        recordStoreRepository.DisplayOrderHistoryByLocation(locationID);
                        break;
                    case "h":

                            Environment.Exit(0);

                        break;
                }
            } while (true);
        }
    }
}