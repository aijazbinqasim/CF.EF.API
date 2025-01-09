using Microsoft.AspNetCore.Mvc;

namespace Web.App.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
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
