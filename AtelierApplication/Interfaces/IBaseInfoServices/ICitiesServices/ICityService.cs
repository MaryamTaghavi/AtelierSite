using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices
{
	public interface ICityService
	{
		public List<SelectListItem> GetAllSelectList();
	}
}
