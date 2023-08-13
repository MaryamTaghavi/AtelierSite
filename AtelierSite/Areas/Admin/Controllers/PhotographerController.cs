using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IPhotographersService;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]

	public class PhotographerController : Controller
    {
		private readonly IPhotographerService _photographerService;

		public PhotographerController(IPhotographerService photographerService)
		{
			_photographerService = photographerService;
		}

		public IActionResult Index(int id)
        {
			ViewBag.AtelierId=id;
            return View(_photographerService.GetAllPhotographer(id));
        }

		public IActionResult AddPhotographer(int id)
		{
			return View(new PhotographersViewModel()
            {
				AtelierId = id
            });
		}

		[HttpPost]
		public IActionResult AddPhotographer(PhotographersViewModel photographersViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(photographersViewModel);
			}
			_photographerService.Add(photographersViewModel);

			return RedirectToAction("Index",new {area="Admin",id=photographersViewModel.AtelierId});
		}


		public IActionResult EditPhotographer(int id)
		{
			var model = _photographerService.GetByIdPhotographerViewModel(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult EditPhotographer(PhotographersViewModel photographersViewModel)
		{
			if (!ModelState.IsValid)
				return View(photographersViewModel);

			_photographerService.UpdateDto(photographersViewModel);
			return RedirectToAction("Index", new { area = "Admin", id = photographersViewModel.AtelierId });
		}

		public RequestResult DeletePhotographer(int id)
		{
			return _photographerService.Delete(id);
		}

	}
}
