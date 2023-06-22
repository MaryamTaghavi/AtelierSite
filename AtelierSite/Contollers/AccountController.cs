using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Contollers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
