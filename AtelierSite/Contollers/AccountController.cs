﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Contollers
{
	public class AccountController : Controller
	{
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = null)
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login()
		{
			return View();
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
	}
}
