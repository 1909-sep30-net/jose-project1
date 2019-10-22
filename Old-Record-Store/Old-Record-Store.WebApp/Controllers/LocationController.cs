using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Old_Record_Store.Library;
using Old_Record_Store.WebApp.Models;

namespace Old_Record_Store.WebApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly IRecordStoreRepository _repository;

        public LocationController(IRecordStoreRepository repository)
        {
            _repository = repository;
        }
        // GET: Location
        public ActionResult Index()
        {
            List<Location> locList = _repository.DisplayLocations();
            IEnumerable<LocationViewModel> locModelList = locList.Select(x => new LocationViewModel
            {
                Name = x.Name,
                LocationId = x.LocationId,
                Inventory = x.Inventory.Select(i => new InventoryViewModel
                { 
                    LocationId = i.LocationId,
                    RecordId = i.RecordId,
                    Stock = i.Stock
                }).ToHashSet()

            });

            return View(locModelList);

        }

        public ActionResult GetLocationID(FormLocationID getID)
        {
            return View(getID);
        }

        public ActionResult GetInventoryLocationID(FormInventoryLocationID getID)
        {
            return View(getID);
        }


        public ActionResult DisplayInventory(FormInventoryLocationID getID)
        {
            var db = _repository.DisplayInventoryFromLocation(getID.LocationID).ToList();
            var inventoryModelList = new List<InventoryViewModel>();
            foreach (var item in db)
            {
                inventoryModelList.Add(new InventoryViewModel()
                {
                    LocationId = item.LocationId,
                    RecordId = item.RecordId,
                    Stock = item.Stock
                });
            }
            return View(inventoryModelList);
        }


        public ActionResult GetLocationOrderHistory(FormLocationID search)
        {
            int id = search.LocationID;
            List<Orders> LocationOrders = _repository.DisplayOrderHistoryByLocation(id);
            IEnumerable<OrderViewModel> orderModelList = LocationOrders.Select(x => new OrderViewModel
            {
                OrderId = x.OrderId,
                LocationId = x.LocationId,
                CustomerId = x.CustomerId,
                OrderTotal = x.OrderTotal,
                Date = x.Date
            });

            return View(orderModelList);
        }


        // GET: Location/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
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