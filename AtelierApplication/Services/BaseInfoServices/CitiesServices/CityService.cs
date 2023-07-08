using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Services.BaseInfoServices.CitiesServices
{
	public class CityService : ICityService
	{
		private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
			_cityRepository = cityRepository;
        }

		
		public List<City> GetAll()
		{
			return _cityRepository.GetAll();

		}

		public List<SelectListItem> GetAllSelectList()
		{
			var list = new List<SelectListItem>()
			{
				new SelectListItem()
				{
					Value = null,
					Text = "شهر"
				}
			};

			list.AddRange(_cityRepository.GetAllSelectList());
			;
			return list;
		}

		public List<CitySelectDto> GetAllCities()
		{
			return _cityRepository.GetAllCities();
		}

		public City GetById(int id)
		{
			return _cityRepository.GetById(id);
		}

		public CityDto GetByIdCityDto(int id)
		{
			return _cityRepository.GetByIdCityDto(id);
		}

		public void Add(CityDto cityDto)
		{
			City city = new City()
			{
				Title = cityDto.Title
			};
			_cityRepository.Add(city);
		}

		public RequestResult Delete(int id)
		{
			var city = GetById(id);
			city.DeletedDate = DateTime.Now;
			Update(city);
			return new RequestResult(true, RequestResultStatusCode.Success, "شهر با موفقیت حذف شد");
		}

		public void Update(City city)
		{
			city.EditedDate = DateTime.Now;
			_cityRepository.Update(city);
		}

		public void UpdateDto(CityDto cityDto)
		{
			var city = GetById(cityDto.Id);
			city.Title = cityDto.Title;
			Update(city);
		}
	}
}
