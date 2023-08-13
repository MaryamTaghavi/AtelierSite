using System;
using System.Collections.Generic;
using System.Linq;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
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
		private readonly IAtelierService _atelierService;

		public SearchAtelierController(IAtelierGroupService atelierGroupService, IAtelierService atelierService)
		{
			_atelierGroupService = atelierGroupService;
			_atelierService = atelierService;
		}

		[AllowAnonymous]
		public IActionResult Atelier(string title, int cityId, int groupingId)
		{
			var userId = User.GetUserId();
			return View(_atelierGroupService.SearchAtelier(new SearchViewModel() {UserId = userId,CityId = cityId, GroupingId = groupingId, Title = title }).ToList());
		}

		[HttpPost]
		public IActionResult FilterAtelier(List<string> groupingIds , List<string> cityIds)
		{
			var list = _atelierGroupService.FilterAtelier(groupingIds, cityIds);
			return PartialView("AtelierPartial", list);
		}

		public IActionResult AtelierDetails(int atelierId)
		{
			var list = _atelierService.GetAtelierById(atelierId);
			return View(list);
		}

	}
}
