namespace Web.App.Frontend.Controllers
{

    // Attribute routing
    //[Route("shop")]
    public class ProductController : Controller
    {

        //[Route("plist")]
        //public ViewResult Products()
        //{
        //    return View();
        //}

        public ViewResult Products()
        {
            HttpContext.Session.SetString("Name", "Walidad Brohi");
            HttpContext.Session.SetInt32("Age", 22);

            return View();
        }


    }
}
