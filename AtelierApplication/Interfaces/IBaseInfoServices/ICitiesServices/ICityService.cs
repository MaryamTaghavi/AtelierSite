using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.Models.BaseInfo.Cities;

namespace Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices
{
	public interface ICityService
	{
		List<City> GetAll();
		public List<SelectListItem> GetAllSelectList();
	}
}
