using HelenaGrace.Models;
using HelenaGrace.Models.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            UserBusinessService ubs = new UserBusinessService();
            return View(ubs.FindUser());
        }

        public IActionResult UpdateProfileView()
        {
            UserBusinessService ubs = new UserBusinessService();
            return View(ubs.FindUser());
        }

        public IActionResult UpdateProfile(User user)
        {
            UserBusinessService ubs = new UserBusinessService();
            if (ubs.UpdateProfile(user))
            {
                return View("Index", ubs.FindUser());
            }
            else
            {
                ViewData.Add("Message", "Profile update failed.");
                return View("UpdateProfileView");
            }
        }
    }
}
