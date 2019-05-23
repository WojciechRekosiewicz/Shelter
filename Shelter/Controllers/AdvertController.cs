using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shelter.Models;

namespace Shelter.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public IActionResult List()
        {
            var adverts = _advertRepository.GetAllAdverts().OrderBy(p => p.Title);

            return View(adverts);
        }

        public IActionResult MyAdverts()
        {
            if (User.Identity.IsAuthenticated)
            {
                var adverts = _advertRepository.GetAdvertsByUserId(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return View(adverts);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        public IActionResult Details(int id)
        {
            var advert = _advertRepository.GetAdvertById(id);
            if (advert == null)
            {
                return NotFound();
            }

            return View(advert);
        }
        [HttpGet]
        public IActionResult Create(string errorMessage = null)
        {
            if(User.Identity.IsAuthenticated)
            {
                ViewData["Message"] = errorMessage;
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        [HttpPost]
        public IActionResult Create(Advert advert)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Getting user's Id from the session
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                advert.AuthorId = userId;

                // Render back to the creation route, otherwise validation does not work
                if (advert.Title == null || advert.ShortDescription == null || advert.LongDescription == null) return Create();

                // Custom image if user does not provide any
                if (advert.ImageUrl == null) advert.ImageUrl = "https://img.tickld.com/filter:scale/quill/e/7/1/3/2/9/e7132910dcc33f74a29ac914162f97e82624ce06.jpg?mw=650";

                _advertRepository.Create(advert);
                return Redirect("/");
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult Reserve(string errorMessage = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Message"] = errorMessage;
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }


        [HttpPost]
        public IActionResult Reserve(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var advert = _advertRepository.GetAdvertById(id);
                if (advert.ReservingId == null && !advert.AuthorId.Equals(userId))
                {

                    advert.ReservingId = userId;

                    var user = _advertRepository.GetUserById(userId);
                    _advertRepository.Update(advert);

                    Console.WriteLine(user.Email);
                    Console.WriteLine(user.Id);

                    return View(advert);

                }
                else
                {
                    return Redirect("/");
                }

            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
        public IActionResult Delete(int id)
        {
            // Check if user is logged in
            if (User.Identity.IsAuthenticated)
            {
                // Getting logged in user's id
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                
                if (_advertRepository.CanDelete(userId, id))
                {
                    _advertRepository.Delete(id);

                    // TODO: Redirect to proper page with detailed information
                    return Redirect("/");
                }
                else
                {
                    // TODO: Redirect to proper page with detailed information
                    return Redirect("/");
                }
            }

            return Redirect("/");
        }
    }
}