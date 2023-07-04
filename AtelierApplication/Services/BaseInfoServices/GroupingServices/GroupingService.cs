using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Utilities;
using Atelier.Application.Helpers;
using Atelier.Domain.Models.BaseInfo;

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
        public List<GroupingSelectDto> GetAllGrouping()
        {
	        return _groupingRepository.GetAllGrouping();
        }

		public Grouping GetById(int id)
        {
			return _groupingRepository.GetById(id);
		}


		public void Add(GroupingDto groupingDto)
        {
            var fileNameAddress = groupingDto.GroupPic.SaveFile("images\\GroupingImages\\");

            Grouping grouping = new Grouping()
            {
                Title = groupingDto.Title,
                GroupPic = fileNameAddress
			};
            _groupingRepository.Add(grouping);

        }

		public RequestResult Delete(int id)
        {
			var grouping = GetById(id);

			grouping.DeletedDate = DateTime.Now;

			Update(grouping);

			return new RequestResult(true, RequestResultStatusCode.Success, "مشتری با موفقیت حذف شد.");
		}

		public void Update(Grouping grouping)
		{
			grouping.EditedDate = DateTime.Now;
			_groupingRepository.Update(grouping);
		}

		public void UpdateDto(GroupingDto groupingDto)
        {
	        var grouping = GetById(groupingDto.Id);

	        if (groupingDto.GroupPic!=null)
	        {
		        grouping.GroupPic.DeleteFile();
		        var fileNameAddress = groupingDto.GroupPic.SaveFile("images\\GroupingImages\\");
				grouping.GroupPic = fileNameAddress;

	        }
	        grouping.Title=groupingDto.Title;
	        Update(grouping);
		}

		public GroupingDto GetByIdGroupingDto(int id)
		{
			return _groupingRepository.GetByIdGroupingDto(id);
		}
	}
}
