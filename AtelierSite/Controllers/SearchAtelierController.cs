using System.Collections.Generic;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AtelierSite.Controllers
{
	public class SearchAtelierController : Controller
	{
		[AllowAnonymous]
		public IActionResult Atelier()
		{
            var data = HttpContext.Session.GetString("Data");
            var list1 = JsonConvert.DeserializeObject<List<AtelierSearchResultDto>>(data);
			return View(list1);
		}
	}
}
