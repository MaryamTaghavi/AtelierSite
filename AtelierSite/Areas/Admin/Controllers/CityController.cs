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
            return View(new CityDto());
        }

        [HttpPost]
        public IActionResult AddCity(CityDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return View(cityDto);
            }
            _cityService.Add(cityDto);

            return RedirectToAction("Index");
        }

        public IActionResult EditCity(int id)
        {
	        var model = _cityService.GetByIdCityDto(id);
	        return View(model);
        }

        [HttpPost]
        public IActionResult EditCity(CityDto cityDto)
        {
	        if (!ModelState.IsValid)
		        return View(cityDto);

	        _cityService.UpdateDto(cityDto);
	        return RedirectToAction("Index");
        }

        public RequestResult DeleteCity(int id)
        {
            return _cityService.Delete(id);
        }
    }
}
