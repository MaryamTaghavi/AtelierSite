using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
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
    }
}
