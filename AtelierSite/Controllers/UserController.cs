using Atelier.Application.Services.BaseInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Controllers
{
	public class UserController : Controller
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}
		public IActionResult Index(string id)
		{
			var UserId = int.Parse(id);
			var model = _userService.GetByIdUserDto(UserId);

			return View(model);
		}
	}
}
