using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Models.BaseInfo.Cities;
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
    }


}
