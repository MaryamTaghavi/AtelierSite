using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Models.BaseInfo.Ateliers;

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

		public List<AtelierSearchResultDto> SearchAtelier(SearchDto dto)
		{
			return _atelierGroupRepository.SearchAtelier(dto);
		}
	}
}
