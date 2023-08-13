using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IWorkSamplesServices;
using Atelier.Application.Utilities;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IWorkSamplesRepository;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Atelier.Domain.Models.BaseInfo.WorkSamples;

namespace Atelier.Application.Services.BaseInfoServices.WorkSamplesServices
{
	public class WorkSampleService : IWorkSampleService
	{
		private readonly IWorkSampleRepository _workSampleRepository;

		public WorkSampleService(IWorkSampleRepository workSampleRepository)
		{
			_workSampleRepository = workSampleRepository;
		}

		public List<WorkSample> GetAll()
		{
			return _workSampleRepository.GetAll();
		}

		public List<WorkSampleShowViewModel> GetAllWorkSample(int atelierId)
		{
			return _workSampleRepository.GetAllWorkSample(atelierId);
		}

		public WorkSample GetById(int id)
		{
			return _workSampleRepository.GetById(id);
		}

		public WorkSampleViewModel GetByIdWorkSampleViewModel(int id)
		{
			return _workSampleRepository.GetByIdWorkSampleViewModel(id);
		}

		public void Add(WorkSampleViewModel workSampleViewModel)
		{
			var fileNameAddress = workSampleViewModel.WorkSamplePic.SaveFile("images\\WorkSampleImages\\");

			WorkSample workSample = new WorkSample()
			{
				WorkSamplePic = fileNameAddress,
				GroupId = workSampleViewModel.GroupId,
				AtelierId = workSampleViewModel.AtelierId
			};
			_workSampleRepository.Add(workSample);
		}

		public RequestResult Delete(int id)
		{
			var workSample = GetById(id);

			workSample.DeletedDate = DateTime.Now;

			Update(workSample);

			return new RequestResult(true, RequestResultStatusCode.Success, "نمونه کار با موفقیت حذف شد.");
		}

		public void Update(WorkSample workSample)
		{
			workSample.EditedDate = DateTime.Now;
			_workSampleRepository.Update(workSample);
		}

		public void UpdateDto(WorkSampleViewModel workSampleViewModel)
		{
			var workSample = GetById(workSampleViewModel.Id);
			if (workSampleViewModel.WorkSamplePic != null)
			{
				workSample.WorkSamplePic.DeleteFile();
				var fileNameAddress = workSampleViewModel.WorkSamplePic.SaveFile("images\\WorkSampleImages\\");
				workSample.WorkSamplePic = fileNameAddress;

			}
			workSample.GroupId = workSampleViewModel.GroupId;
			//workSample.AtelierId = workSampleViewModel.AtelierId;
			Update(workSample);
		}
	}
}
