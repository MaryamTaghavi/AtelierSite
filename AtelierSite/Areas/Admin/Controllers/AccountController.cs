using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AtelierSite.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		[Route("/Admin/Login")]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[Route("/Admin/Login")]
		[HttpPost]
		public IActionResult Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginViewModel);
			}
			var user = _userService.LoginUser(loginViewModel, TypeUser.Admin);

			if (user != null)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
					new Claim(ClaimTypes.Name,user.UserName),
					new Claim(ClaimTypes.Role,"Admin"),
					new Claim("FullName", user.FullName),
				};
				var identity = new ClaimsIdentity(claims, "Admin_Schema");
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties
				{
					IsPersistent = true
				};
				HttpContext.SignInAsync("Admin_Schema", principal, properties);


				return RedirectToAction("Index", "Home" ,new { Area = "Admin" });
			}

			return View(loginViewModel);
		}

		[Route("/Admin/Logout")]
		[Authorize]
		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync("Admin_Schema");
			return RedirectToAction("Login", "Account", new { Area = "Admin" });
		}
	}
}
