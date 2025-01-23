namespace Web.App.Frontend.Controllers
{
    public class BookController : Controller
    {
        public ViewResult SingleBook()
        {
            var bookModel = new BookModel
            {
                Id = 1,
                Title = "Professional C# 7 and .NET Core 2.0",
                Price = 47.99M,
                ISBN = "9781119449270",
                Remarks = "The best-selling C# book"
            };

            HttpContext.Session.Set("book", bookModel);

            HttpContext.Session.Set("isvalid", true);
            return View();
        }

        public ViewResult DisplayBook()
        {
            var book = HttpContext.Session.Get<BookModel>("book");
            return View(book);
        }
    }
}
