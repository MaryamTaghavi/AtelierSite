using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;

		}

		public IActionResult Index()
		{
			return View(_userService.GetAll());
		}

		//public IActionResult AddUser()
		//{
		//	return View();
		//}

		public IActionResult EditUser(int id)
		{
			var model = _userService.GetByIdUserDto(id);

			return View(model);
		}
		[HttpPost]
		public IActionResult EditUser(UserViewModel userViewModel)
		{
			if (!ModelState.IsValid)
				return View(userViewModel);

			_userService.UpdateDto(userViewModel);
			return RedirectToAction("Index");
		}


		public RequestResult DeleteUser(int id)
		{
			return _userService.Delete(id);
		}
	}
}
