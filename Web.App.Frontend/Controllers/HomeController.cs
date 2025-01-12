using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.App.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // passing data from controller to view.

          
            //ViewBag.Username = "Walidad";
            //ViewBag.Age = 22;
            //ViewBag.HasJob = true;

            //ViewBag.ComplexData = new { Id = 1, Name = "Aijaz" };


            TempData["Username"] = "Walidad";
            TempData["Age"] = 22;
            TempData["HasJob"] = true;

            TempData["ComplexData"] =
                JsonSerializer.Serialize<dynamic>(new { Id = 1, Name = "Aijaz" });

            // return View();

            return RedirectToAction("About");
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact() 
        { 
            return View("ContactUs");
        }
    }
}
