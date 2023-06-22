using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
