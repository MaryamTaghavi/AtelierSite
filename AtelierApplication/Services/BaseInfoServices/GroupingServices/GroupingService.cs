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

namespace Atelier.Application.Services.BaseInfoServices.GroupingServices
{
	public class GroupingService : IGroupingService
	{
		private readonly IGroupingRepository _groupingRepository;
        private readonly IHostingEnvironment _environment;
        public GroupingService(IGroupingRepository groupingRepository, IHostingEnvironment hostingEnvironment)
        {
			_groupingRepository = groupingRepository;
            _environment = hostingEnvironment;
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


        public void Add(GroupingDto groupingDto)
        {
            var uploadedResult = UploadFile(groupingDto.GropuPic);

            Grouping group = new Grouping()
            {
                Tilte = groupingDto.Title,
                GroupPic = uploadedResult.FileNameAddress
            };
            _groupingRepository.Add(group);

        }


        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\GroupingImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
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
