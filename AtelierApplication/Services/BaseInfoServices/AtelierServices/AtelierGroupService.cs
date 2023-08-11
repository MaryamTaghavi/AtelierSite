﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atelier.Application.Services.BaseInfoServices.AtelierServices
{
	public class AtelierGroupService : IAtelierGroupService
	{
		private readonly IAtelierGroupRepository _atelierGroupRepository;

		public AtelierGroupService(IAtelierGroupRepository atelierGroupRepository)
		{
			_atelierGroupRepository = atelierGroupRepository;
		}

		

		public List<AtelierGroup> GetAll()
		{
			return _atelierGroupRepository.GetAll();
		}

		public List<AtelierShowViewModel> SearchAtelier(SearchViewModel viewModel)
		{
			return _atelierGroupRepository.SearchAtelier(viewModel);
		}

		public List<AtelierShowViewModel> FilterAtelier(List<string> groupingIds, List<string> cityIds)
		{
			List<int> groupings = groupingIds[0] != null ? groupingIds[0].Split(',').Select(r => int.Parse(r)).ToList() : new List<int>();
			List<int> cities = cityIds[0] != null
				? cityIds[0].Split(',').Select(r => int.Parse(r)).ToList()
				: new List<int>();

			return _atelierGroupRepository.FilterAtelier(groupings , cities);
		}

        public List<SelectListItem> GetAllAtelierGroupByAtelierId(int atelierId)
        {
            return _atelierGroupRepository.GetAllAtelierGroupByAtelierId(atelierId);
        }
    }
}
