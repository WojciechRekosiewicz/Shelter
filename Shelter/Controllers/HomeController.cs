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
            var adverts = _advertRepository.GetAllAdverts().OrderBy(p => p.Title);
            return View(adverts);
        }

        public IActionResult Details(int id)
        {
            var advert = _advertRepository.GetAdvertById(id);
            if(advert == null)
            {
                return NotFound();
            }

            return View(advert);
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
