using Atelier.Data.Context;
using Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository;
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

        public List<SelectListItem> GetAllSelectList()
		{
			return _context.Cities.Select(r => new SelectListItem()
			{
				Text = r.Tilte,
				Value = r.Id.ToString()
			}
			).ToList();
		}
	}
}
