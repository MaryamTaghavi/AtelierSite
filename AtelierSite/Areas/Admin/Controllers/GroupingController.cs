using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGrouping()
        {
	        return View();
        }

        [HttpPost]
        public IActionResult AddGrouping(GroupingDto groupingDto)
        {
            return View();
        }
    }
}
