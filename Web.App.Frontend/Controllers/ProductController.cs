namespace Web.App.Frontend.Controllers
{

    // Attribute routing
    [Route("shop")]
    public class ProductController : Controller
    {

        [Route("plist")]
        public ViewResult Products()
        {
            return View();
        }
    }
}
