using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Contollers
{
	[AllowAnonymous]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
