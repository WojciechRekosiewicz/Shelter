using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shelter.Models;
using Shelter.ViewModels;

namespace Shelter.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
            
        public AdvertController(IAdvertRepository advertRepository, IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _advertRepository = advertRepository;
            _userRepository = userRepository;
            _userManager = userManager;
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
                // Previous approach which was iterating through all users trying to find matching one
                // User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userId = _userManager.GetUserId(HttpContext.User);
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
                var userId = _userManager.GetUserId(HttpContext.User);
                var advert = _advertRepository.GetAdvertById(id);
                var authorId = advert.AuthorId;

                if (advert.ReservingId == null && !advert.AuthorId.Equals(userId))
                {
                    // Updating model
                    var user = _userRepository.GetUserById(authorId);
                    advert.ReservingId = userId;
                    _advertRepository.Update(advert);
                    
                    var viewModel = new AdvertViewModel()
                    {
                        Title = advert.Title,
                        User = user
                    };

                    return View(viewModel);

                }
                else
                {
                    return Redirect($"/Advert/Details/{id}");
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
                var userId = _userManager.GetUserId(HttpContext.User);

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