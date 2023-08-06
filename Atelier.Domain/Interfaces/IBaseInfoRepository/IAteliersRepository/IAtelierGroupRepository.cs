using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository
{
	public interface IAtelierGroupRepository
	{
		List<AtelierGroup> GetAll();
		List<SelectListItem> GetAllAtelierGroupByAtelierId(int atelierId);
		void DeleteAllAtelierGroup(int atelierId);
		void AddRangeOAtelierGroup(List<AtelierGroup> list);
		List<AtelierSearchResultViewModel> SearchAtelier(SearchViewModel viewModel);
		List<AtelierSearchResultViewModel> FilterAtelier(List<int> groupIds , List<int> cityIds);

	}
}
