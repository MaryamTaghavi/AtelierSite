using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    [Area("Admin")]
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
	        return View(new GroupingDto());
        }

        [HttpPost]
        public IActionResult AddGrouping(GroupingDto groupingDto)
        {
			if (!ModelState.IsValid)
			{
				return View(groupingDto);
			}
			_groupingService.Add(groupingDto);

			return RedirectToAction("Index");
		}

        public IActionResult EditGrouping(int id)
        {
	        var model = _groupingService.GetByIdGroupingDto(id);
	        return View(model);
        }

        [HttpPost]
        public IActionResult EditGrouping(GroupingDto grouping)
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
