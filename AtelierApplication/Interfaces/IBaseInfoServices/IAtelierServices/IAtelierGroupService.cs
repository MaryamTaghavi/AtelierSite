using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices
{
	public interface IAtelierGroupService
	{
		List<AtelierGroup> GetAll();
        List<SelectListItem> GetAllAtelierGroupByAtelierId(int atelierId);
        List<AtelierShowViewModel> SearchAtelier(SearchViewModel viewModel);
		List<AtelierShowViewModel> FilterAtelier(List<string> groupingIds, List<string> cityIds);
	}
}
