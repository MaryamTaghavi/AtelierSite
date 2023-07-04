using Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices;
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
	}
}
