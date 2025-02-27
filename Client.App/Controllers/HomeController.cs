using Microsoft.AspNetCore.Mvc;

namespace Client.App.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
