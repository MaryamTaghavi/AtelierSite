using Atelier.Domain.Models.BaseInfo;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository
{
	public interface IGroupingRepository
	{
		List<Grouping> GetAll();
		List<SelectListItem> GetAllSelectList();
        List<GroupingShowViewModel> GetAllGrouping();
        Grouping GetById(int id);
		GroupingViewModel GetByIdGroupingDto(int id);
		void Add(Grouping grouping);
        void Update(Grouping grouping);
    }
}
