using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shelter.Models;

namespace Shelter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertRepository _advertRepository;

        public HomeController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public IActionResult Index()
        {
            return Redirect("/Advert/List");
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
