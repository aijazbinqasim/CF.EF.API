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


        public JsonResult GetUser()
        {
            var user = new
            {
                Id = 1,
                Name = "Walidad",
                Age = 30,
                Books = new[] { "Java", "Php", "C#", "Python" }
            };


            return Json(user);

        }


        public ViewResult Book()
        {
            ViewBag.Title = "Book";

            var book = new BookModel
            {
                Id = 1,
                Title = "Java",
                ISBN = "RT658UYU",
                Price = 52.5m
            };

            return View(book);
        }


        public ViewResult BookList()
        {
            ViewBag.Title = "Book List";

            var bookList = new List<BookModel>
            {
                 new() { Id = 1, Title = "Java", ISBN = "RT658UYU", Price = 52.5m },
                 new() { Id = 2, Title = "C#", ISBN = "RT6785U", Price = 50.5m },
                 new() { Id = 3, Title = "Php", ISBN = "RT658UYU", Price = 58.5m },
                 new() { Id = 4, Title = "Python", ISBN = "RT658UYU", Price = 11.5m },
                 new() { Id = 5, Title = "React", ISBN = "RT658UYU", Price = 500.5m },
                 new() { Id = 6, Title = "Oracle", ISBN = "RT658UYU", Price = 215.5m }
            }
            .OrderBy(b => b.Title)
            .ToList();

            return View(bookList);
        }

        public ViewResult SaveBook()
        {
            @ViewBag.Title = "Save Book";

            return View();
        }


        [HttpPost]
        public ViewResult SaveBook(BookModel book)
        {
            @ViewBag.Title = "Book Saved!";
            return View(book);
        }


    }
}
