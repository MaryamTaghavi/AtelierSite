using System.Collections.Generic;
using System.Security.Claims;
using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
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
        [Route("/Login")]

        public IActionResult Login()
		{
			return View(new LoginViewModel());
		}
        [Route("/Login")]
        [HttpPost]
		public IActionResult Login(LoginViewModel loginViewModel)
		{
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = _userService.LoginUser(loginViewModel,TypeUser.User);

            if(user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,"User"),
                    new Claim("FullName", user.FullName),
                };
                var identity = new ClaimsIdentity(claims, "User_Schema");
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync("User_Schema", principal, properties);


                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }

        [Route("/Logout")]
        [Authorize]
		public IActionResult LogOut()
		{
            HttpContext.SignOutAsync("User_Schema"); 
            return RedirectToAction("Index" , "Home");
		}


        #region Register
        [Route("/Register")]

        public ActionResult Register()
        {
            return View();
        }
        [Route("/Register")]

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

			var res=_userService.Add(viewModel,TypeUser.User);

            if (res.IsSuccess)
                return RedirectToAction("Login");

            ModelState.AddModelError(nameof(viewModel.UserName),res.Message);
            return View(viewModel);

        }

        #endregion
    }
}
