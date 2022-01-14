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
        private MessageViewModel _messageViewModel;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _messageViewModel = new MessageViewModel();
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


        [HttpPost]
        public IActionResult Process(FormViewModel model, string submit)
        {
            switch (submit)
            {
                case "Greet":
                    return RedirectToAction("Greet", new { fullName = model.FullName });
                case "Reverse":
                    return RedirectToAction("Reverse", new { fullName = model.FullName });
                case "No Vowels":
                    return RedirectToAction("NoVowels", new { fullName = model.FullName });
                case "Only Vowels":
                    return RedirectToAction("OnlyVowels", new { fullName = model.FullName });
            }
            return View();
        }

        public IActionResult Greet(string fullName)
        {
            _messageViewModel.Message = $"Hello {fullName}, how are you?";
            return View("Message", _messageViewModel);
        }

        public IActionResult Reverse(string fullName)
        {
            char[] array = fullName.ToArray();
            Array.Reverse(array);
            _messageViewModel.Message = $"OlleH {new string(array)}";

            return View("Message",_messageViewModel);
        }

        public IActionResult NoVowels(string fullName)
        {
            string vowels = "aeiou";
            string name = new string(fullName.Where(x => !vowels.Contains(x)).ToArray());
            _messageViewModel.Message = $"Hll {name}";

            return View("Message", _messageViewModel);
        }

        public IActionResult OnlyVowels(string fullName)
        {
            string vowels = "aeiou";
            string name = new string(fullName.Where(x => vowels.Contains(x)).ToArray());
            _messageViewModel.Message = $"eo {name}";

            return View("Message", _messageViewModel);
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
