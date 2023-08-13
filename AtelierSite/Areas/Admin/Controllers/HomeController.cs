using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{
		[Area("Admin")]
		[Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
