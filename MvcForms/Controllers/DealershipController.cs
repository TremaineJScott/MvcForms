using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcForms.Models;

namespace MvcForms.Controllers
{
   

    public class DealershipController : Controller
    {
        private List<CarViewModel> cars;

        public DealershipController()
        {
            cars = new List<CarViewModel>();
            cars.Add(new CarViewModel { Id = 1, Make = "Ford", Model = "Mustang", Year = 2000, Transmission = "Manual" });
            cars.Add(new CarViewModel { Id = 2, Make = "Chevy", Model = "Corvette", Year = 2000, Transmission = "Automatic" });
            cars.Add(new CarViewModel { Id = 3, Make = "Dodge", Model = "Viper", Year = 2000, Transmission = "Manual" });
        }
        // GET: DealearshipController
        public ActionResult Index()
        {
            return View(cars);
        }

        [Route("api/details")]
        // GET: DealearshipController/Details/5
        public ActionResult Details(int id)
        {
            CarViewModel car = cars.Where(x => x.Id == id).First();
            return View(car);
        }

        // GET: DealearshipController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealearshipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealearshipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DealearshipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealearshipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DealearshipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
