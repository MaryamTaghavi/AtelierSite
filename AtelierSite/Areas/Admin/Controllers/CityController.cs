using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.Models.BaseInfo.Cities;
using Microsoft.AspNetCore.Mvc;

namespace AtelierSite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CityController : Controller
	{
		private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
		{
			return View(_cityService.GetAllCities());
		}

        public IActionResult AddCity()
        {
            return View(new CityViewModel());
        }

        [HttpPost]
        public IActionResult AddCity(CityViewModel cityViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cityViewModel);
            }
            _cityService.Add(cityViewModel);

            return RedirectToAction("Index");
        }

        public IActionResult EditCity(int id)
        {
	        var model = _cityService.GetByIdCityDto(id);
	        return View(model);
        }

        [HttpPost]
        public IActionResult EditCity(CityViewModel cityViewModel)
        {
	        if (!ModelState.IsValid)
		        return View(cityViewModel);

	        _cityService.UpdateDto(cityViewModel);
	        return RedirectToAction("Index");
        }

        public RequestResult DeleteCity(int id)
        {
            return _cityService.Delete(id);
        }
    }
}
