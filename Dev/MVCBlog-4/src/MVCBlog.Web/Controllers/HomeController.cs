using Microsoft.AspNetCore.Mvc;

namespace MVCBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
