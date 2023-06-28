using Atelier.Data.Context;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Data.Repositories.BaseInfoRepository.GroupingRepositories
{
	public class GroupingRepository : IGroupingRepository
	{
		private readonly AtelierContext _context;

        public GroupingRepository(AtelierContext context)
        {
            _context = context;
        }

        public List<Grouping> GetAll()
		{
			return _context.Groupings.ToList();
		}

		public List<SelectListItem> GetAllSelectList()
		{
			return _context.Groupings.Select(r => new SelectListItem()
			{
				Text = r.Tilte,
				Value = r.Id.ToString()
			}).ToList();
		}
	}
}
