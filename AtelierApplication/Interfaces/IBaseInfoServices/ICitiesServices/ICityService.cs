using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Cities;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;

namespace Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices
{
	public interface ICityService
	{
		List<City> GetAll();
		public List<SelectListItem> GetAllSelectList();
		List<CityShowViewModel> GetAllCities();
		City GetById(int id);
		CityViewModel GetByIdCityDto(int id);
		void Add(CityViewModel cityViewModel);
		RequestResult Delete(int id);
		void Update(City city);
		void UpdateDto(CityViewModel cityViewModel);

	}
}
