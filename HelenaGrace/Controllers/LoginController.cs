using HelenaGrace.Models;
using HelenaGrace.Models.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(User user)
        {
            UserBusinessService ubs = new UserBusinessService();
            if (ubs.Authenticate(user))
            {
                return View("/Views/Artist/Index.cshtml", user);
            }
            else
            {
                ViewData.Add("Message", "Login failed. Please try again.");
                return View("Index");
            }
        }
    }
}
