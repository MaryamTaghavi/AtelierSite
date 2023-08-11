using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IFavoriteServices;
using Atelier.Application.Security;
using Atelier.Application.Services.BaseInfoServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Controllers
{
	[Authorize(Roles = "User", AuthenticationSchemes = "User_Schema")]

	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IFavoriteService _favoriteService;

		public UserController(IUserService userService, IFavoriteService favoriteService)
		{
			_userService = userService;
			_favoriteService = favoriteService;
		}

		public IActionResult Index()
		{
			var userId = User.GetUserId();

			var model = _userService.GetByIdUserDto(userId);

			return View(model);
		}

        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {
			//if (!ModelState.IsValid)
			//    return View(userViewModel);

			_userService.UpdateDto(userViewModel);

			//var userId = User.GetUserId();
			//var model = _userService.GetByIdUserDto(userId);

			return View(userViewModel);
        }

        public IActionResult FavoriteUser()
        {
			var userId = User.GetUserId();

			var model = _favoriteService.GetFavoriteByUserId(userId);

			return View(model);
        }


        public bool AddOrDeleteFavorite(int id)
        {
			return	_favoriteService.AddOrDelete(id,User.GetUserId());
        }
	}
}
