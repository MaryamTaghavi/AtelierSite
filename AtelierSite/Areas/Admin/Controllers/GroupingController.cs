using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]

	public class GroupingController : Controller
    {
	    private readonly IGroupingService _groupingService;

	    public GroupingController(IGroupingService groupingService)
	    {
		    _groupingService = groupingService;
	    }

	    public IActionResult Index()
        {
            return View(_groupingService.GetAllGrouping());
        }

        public IActionResult AddGrouping()
        {
	        return View(new GroupingViewModel());
        }

        [HttpPost]
        public IActionResult AddGrouping(GroupingViewModel groupingViewModel)
        {
			if (!ModelState.IsValid)
			{
				return View(groupingViewModel);
			}
			_groupingService.Add(groupingViewModel);

			return RedirectToAction("Index");
		}

        public IActionResult EditGrouping(int id)
        {
	        var model = _groupingService.GetByIdGroupingDto(id);
	        return View(model);
        }

        [HttpPost]
        public IActionResult EditGrouping(GroupingViewModel grouping)
        {
	        if (!ModelState.IsValid)
		        return View(grouping);

	        _groupingService.UpdateDto(grouping);

	        return RedirectToAction("Index");
        }

        public RequestResult DeleteGrouping(int id)
        {
	        return _groupingService.Delete(id);
        }
	}
}
