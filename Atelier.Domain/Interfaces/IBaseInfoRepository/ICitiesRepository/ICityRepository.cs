using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Cities;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository
{
	public interface ICityRepository
	{
		List<City> GetAll();
		List<SelectListItem> GetAllSelectList();
	}
}
