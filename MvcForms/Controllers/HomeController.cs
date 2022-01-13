using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcForms.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcForms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Greeting(FormViewModel model)
        {
            if (model.FirstName.ToLower().Trim() == model.LastName.ToLower().Trim())
            {
                model.IsSameName = true;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ProcessFavorites(FormViewModel model)
        {
            FavoritesViewModel favorites = new FavoritesViewModel();
            favorites.Animal = model.Animal;
            string animal = model.Animal.Trim().ToLower();
            switch (animal)
            {
                case "cat":
                case "kitten":
                    favorites.Message = "You like the furballs eh?";
                    break;
                case "dog":
                case "puppy":
                    favorites.Message = "No litter box for you.";
                    break;
                default:
                    favorites.Message = "I don't know what that is.";
                    break;
            }
            return View(favorites);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
