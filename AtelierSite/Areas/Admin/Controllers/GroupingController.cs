using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    public class GroupingController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
