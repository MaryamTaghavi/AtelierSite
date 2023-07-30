using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository;
using Atelier.Domain.Models.BaseInfo.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Data.Repositories.BaseInfoRepository.CitiesRepositories
{
	public class CityRepository : ICityRepository
	{
		private readonly AtelierContext _context;

        public CityRepository(AtelierContext context)
        {
			_context = context;
        }

        public List<City> GetAll()
		{
			return _context.Cities.ToList();
		}

        public List<SelectListItem> GetAllSelectList()
		{
			return _context.Cities.Select(r => new SelectListItem()
			{
				Text = r.Title,
				Value = r.Id.ToString()
			}
			).ToList();
		}

        public List<CityShowViewModel> GetAllCities()
        {
	        return _context.Cities.Select(r => new CityShowViewModel()
	        {
		        Id = r.Id,
		        Title = r.Title
	        }).ToList();
        }

		public City GetById(int id)
		{
			return _context.Cities.Find(id);
		}

		public CityViewModel GetByIdCityViewModel(int id)
		{
			return _context.Cities.Where(r => r.Id == id).Select(r => new CityViewModel()
			{
				Id = r.Id,
				Title = r.Title
			}).SingleOrDefault();
		}

		public void Add(City city)
		{
			_context.Cities.Add(city);
			_context.SaveChanges();
		}

		public void Update(City city)
		{
			_context.Cities.Update(city);
			_context.SaveChanges();
		}
	}
}
