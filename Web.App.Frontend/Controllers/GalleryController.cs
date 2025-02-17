namespace Web.App.Frontend.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(string name, string email, int age, bool? btn)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Age = age;
            ViewBag.isSubmitted = btn;

            return View();
        }
    }
}
