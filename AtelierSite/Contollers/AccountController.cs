using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Microsoft.AspNetCore.Authorization;
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

        #region Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public ActionResult Register(RegisterDto dto)
        {
            return View();
        }

        #endregion
    }
}
