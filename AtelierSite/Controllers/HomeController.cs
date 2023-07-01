using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
	        return View();
        }

		[HttpGet]
		public IActionResult SearchAtelier(string text , int groupId , int cityId)
		{
			var list = _atelierGroupService.SearchAtelier(text, groupId, cityId).ToList();

			return RedirectToAction("Atelier", "SearchAtelier", new {list = JsonConvert.SerializeObject(list) });
        }


	}


}
