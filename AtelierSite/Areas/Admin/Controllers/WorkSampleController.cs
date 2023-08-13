using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IWorkSamplesServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]

	public class WorkSampleController : Controller
	{
		private readonly IWorkSampleService _workSampleService;

		public WorkSampleController(IWorkSampleService workSampleService)
		{
			_workSampleService = workSampleService;
		}

		public IActionResult Index(int id)
		{
			ViewBag.AtelierId = id;
			return View(_workSampleService.GetAllWorkSample(id));
		}

		public IActionResult AddWorkSample(int id)
		{
			return View(new WorkSampleViewModel()
			{
				AtelierId = id
			});
		}

		[HttpPost]
		public IActionResult AddWorkSample(WorkSampleViewModel workSampleViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(workSampleViewModel);
			}
			_workSampleService.Add(workSampleViewModel);

			return RedirectToAction("Index", new { area = "Admin", id = workSampleViewModel.AtelierId });
		}

		
		public IActionResult EditWorkSample(int id)
		{
			var model = _workSampleService.GetByIdWorkSampleViewModel(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult EditWorkSample(WorkSampleViewModel workSampleViewModel)
		{
			if (!ModelState.IsValid)
				return View(workSampleViewModel);

			_workSampleService.UpdateDto(workSampleViewModel);
			return RedirectToAction("Index", new { area = "Admin", id = workSampleViewModel.AtelierId });

		}

		public RequestResult DeleteWorkSample(int id)
		{
			return _workSampleService.Delete(id);
		}
	}
}
