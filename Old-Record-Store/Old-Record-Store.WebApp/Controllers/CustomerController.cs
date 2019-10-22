using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Old_Record_Store.Library;
using Old_Record_Store.WebApp.Models;

namespace Old_Record_Store.WebApp.Controllers
{

    public class CustomerController : Controller
    {
        private readonly IRecordStoreRepository _repository;

        public CustomerController(IRecordStoreRepository repository)
        {
            _repository = repository;
        }
        // GET: Customer
        public ActionResult Index() 
        {

            //    IEnumerable<Customer> custList = _repository.DisplayCustomers();
            List<Customer> custList = _repository.DisplayCustomers();
            IEnumerable<CustomerViewModel> custModelList = custList.Select(x => new CustomerViewModel
                {
                    FullName = x.FullName,
                    Address = x.Address,
                    Email = x.Email,
                    Phone = x.Phone,
                    CustomerId = x.CustomerID
                });
            //var showing = custModelList.ToList();
            return View(custModelList);
        }
        
        // GET: Customer/Details/5
        public ActionResult getCustomerSearch()
        {
            return View();
        }

        /*
         * Gets CUstomer ID Model Binding
         */

        public ActionResult GetCustomerID(FormCustomerID getID)
        {
            return View(getID);
        }

        public ActionResult GetPlaceOrder (FormPlaceOrder getID)
        {
            return View(getID);
        }
        public ActionResult OrderDetails(FormOrderDetails getID)
        {
            return View(getID);
        }
        public ActionResult ViewOrderDetails(FormOrderDetails getID)
        {
            try
            {

                var orderDetails = _repository.DisplayOrderHistoryDetails(getID.OrderID);
                var custOrderModel = new OrderHistoryViewModel()
                {
                    OrderId = orderDetails.OrderId,
                    RecordId = orderDetails.RecordId,
                    RecordAmount = orderDetails.RecordAmount,
                    OrderRecordId = orderDetails.OrderRecordId
                };
                
                return View(custOrderModel);
            }
            catch (System.NullReferenceException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Argument Null Exception! Careful", ex);
                return View();
            }
        }
        public ActionResult PlaceOrder(FormPlaceOrder getID)
        {
            int custID = getID.CustomerID;
            int locID = getID.LocationID;
            int amounts = getID.Amounts;
            int recordID = getID.RecordID;

            var custOrder = _repository.AddToOrder(custID, locID, recordID, amounts);

            var custOrderModel = new OrderHistoryViewModel()
            {
                OrderRecordId = custOrder.OrderRecordId,
                OrderId = custOrder.OrderId,
                RecordId = custOrder.RecordId,
                RecordAmount = custOrder.RecordAmount
            };

            // Display Order Details with Order ID from AddToOrder
            return View(custOrderModel);
        }

 

        /* 
         * Displays Customer Details with given full name
         */
        public ActionResult Details(string fullName)
        {
            try
            { 
                Customer customer = _repository.SeachCustomer(fullName);
                var custModel = new CustomerViewModel()
                {
                    FullName = customer.FullName,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    CustomerId = customer.CustomerID
                };
                return View(custModel);
            }
            catch(NullReferenceException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("Exception handled, Careful", ex);
                return View();
            }
   
            
        }



        /*
         * Displays Customer Order ID order history
         */
        public ActionResult GetCustomerOrderHistory(FormCustomerID search)
        {
            int id = Int32.Parse(search.CustomerID);
            List<Orders> orderList = _repository.DisplayOrderHistoryByCustomer(id);
            IEnumerable<OrderViewModel> orderModelList = orderList.Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                LocationId = x.LocationId,
                CustomerId = x.CustomerId,
                OrderTotal = x.OrderTotal,
                Date = x.Date
            });

            return View(orderModelList);
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create

        /*
         * Adds a customer into the DB 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                var Customer = new Customer
                {
                    FullName = viewModel.FullName,
                    Address = viewModel.Address,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone
                };
                _repository.AddCustomer(Customer);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}