using HelenaGrace.Models;
using HelenaGrace.Models.Business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Controllers
{
    public class ArtistController : Controller
    {
        private IWebHostEnvironment Environment;

        public ArtistController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
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

        public IActionResult UploadDesignView()
        {
            return View();
        }

        public IActionResult UploadDesign(Design design)
        {
            DesignBusinessService dbs = new DesignBusinessService();

            string wwwPath = this.Environment.WebRootPath;

            string path = Path.Combine(wwwPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(design.Picture.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                design.Picture.CopyTo(stream);
            }
            if (dbs.Insert(design))
            {
                ViewData.Add("Message", "Photo upload successful!");
            }
            else
            {
                ViewData.Add("Message", "Photo upload failed.");
            }

            return View("UploadDesignView");
        }
    }
}
