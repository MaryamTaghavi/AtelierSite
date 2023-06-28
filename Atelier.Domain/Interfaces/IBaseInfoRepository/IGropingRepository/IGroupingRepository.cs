using Atelier.Domain.Models.BaseInfo;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository
{
	public interface IGroupingRepository
	{
		List<Grouping> GetAll();
		List<SelectListItem> GetAllSelectList();
	}
}
