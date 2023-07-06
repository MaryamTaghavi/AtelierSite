using System;
using System.Collections.Generic;
using System.Linq;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AtelierSite.Controllers
{
	public class SearchAtelierController : Controller
	{

		private readonly IAtelierGroupService _atelierGroupService;

		public SearchAtelierController(IAtelierGroupService atelierGroupService)
		{
			_atelierGroupService = atelierGroupService;
		}

		[AllowAnonymous]
		public IActionResult Atelier()
		{
            var data = HttpContext.Session.GetString("Data");
            var list1 = JsonConvert.DeserializeObject<List<AtelierSearchResultDto>>(data);
			return View(list1);
		}

		[HttpPost]
		public IActionResult FilterAtelier(List<string> groupingIds , List<string> cityIds)
		{
			var list = _atelierGroupService.FilterAtelier(groupingIds, cityIds);
			return View("Atelier", list);
		}
	}
}
