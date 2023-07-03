using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Models.BaseInfo.Ateliers;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository
{
	public interface IAtelierGroupRepository
	{
		List<AtelierGroup> GetAll();
		List<AtelierSearchResultDto> SearchAtelier(SearchDto dto);
	}
}
