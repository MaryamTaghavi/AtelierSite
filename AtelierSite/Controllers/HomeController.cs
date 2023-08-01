using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AtelierSite.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
    {
        private readonly IAtelierGroupService _atelierGroupService;

        public HomeController(IAtelierGroupService atelierGroupService)
        {
	        _atelierGroupService = atelierGroupService;
        }

        public IActionResult Index()
        {
	        return View(new SearchViewModel());
        }

		[HttpPost]
		public IActionResult SearchAtelier(SearchViewModel viewModel)
		{
			var list = _atelierGroupService.SearchAtelier(viewModel).ToList();
            var list2 = JsonConvert.SerializeObject(list) ;
            HttpContext.Session.SetString("Data", list2);
            return RedirectToAction("Atelier", "SearchAtelier");
		}

	}


}
