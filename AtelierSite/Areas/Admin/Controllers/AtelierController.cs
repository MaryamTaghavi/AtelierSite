using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]

	public class AtelierController : Controller
    {
        private readonly IAtelierService _atelierService;

        public AtelierController(IAtelierService atelierService)
        {
            _atelierService = atelierService;
        }

        public IActionResult Index()
        {
            return View(_atelierService.GetAllAteliers());
        }

        public IActionResult AddAtelier()
        {
            return View(new AtelierViewModel());
        }

        [HttpPost]
        public IActionResult AddAtelier(AtelierViewModel atelierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(atelierViewModel);
            }
            _atelierService.Add(atelierViewModel);

            return RedirectToAction("Index");
        }

        public IActionResult EditAtelier(int id)
        {
	        var model = _atelierService.GetByIdAtelierViewModel(id);
	        return View(model);
        }

        [HttpPost]
        public IActionResult EditAtelier(AtelierViewModel atelierViewModel)
        {
	        if (!ModelState.IsValid)
		        return View(atelierViewModel);

	        _atelierService.UpdateDto(atelierViewModel);

	        return RedirectToAction("Index");
        }

        public RequestResult DeleteAtelier(int id)
        {
	        return _atelierService.Delete(id);
        }
	}
}
