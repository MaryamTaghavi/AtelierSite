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
		List<CitySelectDto> GetAllCities();
		City GetById(int id);
		CityDto GetByIdCityDto(int id);
		void Add(CityDto cityDto);
		RequestResult Delete(int id);
		void Update(City city);
		void UpdateDto(CityDto cityDto);

	}
}
