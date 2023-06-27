using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace AtelierSite.Contollers
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
			return View(new LoginDto());
		}

		[HttpPost]
		public IActionResult Login(LoginDto loginDto)
		{
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }
            var result = _userService.LoginUser(loginDto);

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

            return View(loginDto);
        }
		public IActionResult Logout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Logout(string returnUrl = null)
		{
			return View();
		}

        #region Register

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

			_userService.Add(dto);

            return RedirectToAction("Login");
        }

        #endregion
    }
}
