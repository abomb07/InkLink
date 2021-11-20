using HelenaGrace.Models;
using HelenaGrace.Models.Business;
using Microsoft.AspNetCore.Mvc;

namespace HelenaGrace.Controllers
{
    public class AppointmentController : Controller
    {
        CustomerBusinessService service = new CustomerBusinessService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeAppointment(Appointment appointment) 
        {
            DesignBusinessService dbs = new DesignBusinessService();

            if (service.MakeAppointment(appointment))
            {
                return View("/Views/Home/Index.cshtml", dbs.GetAll());
            }
            else
            {
                ViewData.Add("Message", "Appointment scheduling failed. Please try again.");
                return View("Index");
            }
        }
    }
}
