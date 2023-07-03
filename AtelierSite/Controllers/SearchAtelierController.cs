﻿using System.Collections.Generic;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AtelierSite.Controllers
{
	public class SearchAtelierController : Controller
	{
		[AllowAnonymous]
		public IActionResult Atelier(string list)
		{
			var list1 = JsonConvert.DeserializeObject<List<AtelierSearchResultDto>>(list);
			return View(list1);
		}
	}
}