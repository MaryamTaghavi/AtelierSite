using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Services.BaseInfoServices.GroupingServices
{
	public class GroupingService : IGroupingService
	{
		private readonly IGroupingRepository _groupingRepository;

        public GroupingService(IGroupingRepository groupingRepository)
        {
			_groupingRepository = groupingRepository;
        }

        public List<Grouping> GetAll()
        {
            return _groupingRepository.GetAll();
        }
        public List<SelectListItem> GetAllSelectList()
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "دسته بندی"
                }
            };

            list.AddRange(_groupingRepository.GetAllSelectList());
       
            return list;
        }

        public Grouping GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Grouping grouping)
        {
            Grouping group = new Grouping()
            {
                Tilte = grouping.Tilte,
                GroupPic = grouping.GroupPic
            };
            _groupingRepository.Add(grouping);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Grouping grouping)
        {
            throw new NotImplementedException();
        }
    }
}
