using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices
{
	public interface IGroupingService
	{
		List<Grouping> GetAll();
		public List<SelectListItem> GetAllSelectList();
	}
}
