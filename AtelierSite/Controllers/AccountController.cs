using System.Collections.Generic;
using System.Security.Claims;
using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel loginViewModel)
		{
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var result = _userService.LoginUser(loginViewModel);

            if(result != null)
            {
                var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()),
                        new Claim(ClaimTypes.Name,result.Title),
                        new Claim("LastName", result.FullName),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);


                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }


		[Authorize]
		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index" , "Home");
		}


		#region Register

		public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

			_userService.Add(viewModel);

            return RedirectToAction("Login");
        }

        #endregion
    }
}
