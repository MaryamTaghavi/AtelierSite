using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo;
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

        public List<SelectListItem> GetAllSelectList()
        {
            return _context.Groupings.Select(r => new SelectListItem()
            {
                Text = r.Title,
                Value = r.Id.ToString()
            }).ToList();
        }

        public List<Grouping> GetAll()
        {
            return _context.Groupings.ToList();
        }

        public List<GroupingShowViewModel> GetAllGrouping()
        {
            return _context.Groupings.Select(r => new GroupingShowViewModel()
            {  
                Id = r.Id,
               Title = r.Title,
               GropuPic = r.GroupPic
               
            }).ToList();
        }

        public Grouping GetById(int id)
        {
			return _context.Groupings.Find(id);
		}
        public GroupingViewModel GetByIdGroupingDto(int id)
        {
	        return _context.Groupings.Where(x => x.Id==id).Select(x=> new GroupingViewModel()
	        {
                Id = x.Id,
                Title = x.Title,
	        }).SingleOrDefault();
        }

		public void Add(Grouping grouping )
        {
            _context.Groupings.Add(grouping);
            _context.SaveChanges();
        }


        public void Update(Grouping grouping)
        {
			_context.Update(grouping);
			_context.SaveChanges();
		}


	}
}
