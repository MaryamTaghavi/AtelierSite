﻿using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices
{
	public interface IAtelierGroupService
	{
		List<AtelierGroup> GetAll();
        List<SelectListItem> GetAllAtelierGroupByAtelierId(int atelierId);
        List<AtelierSearchResultViewModel> SearchAtelier(SearchViewModel viewModel);
		List<AtelierSearchResultViewModel> FilterAtelier(List<string> groupingIds, List<string> cityIds);
	}
}
