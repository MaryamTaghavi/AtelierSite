using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.Models.BaseInfo.Photographers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Atelier.Domain.Models.BaseInfo.WorkSamples;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IWorkSamplesServices
{
	public interface IWorkSampleService
	{
		List<WorkSample> GetAll();
		List<WorkSampleShowViewModel> GetAllWorkSample(int atelierId);
		WorkSample GetById(int id);
		WorkSampleViewModel GetByIdWorkSampleViewModel(int id);
		void Add(WorkSampleViewModel workSampleViewModel);
		RequestResult Delete(int id);
		void Update(WorkSample workSample);
		void UpdateDto(WorkSampleViewModel workSampleViewModel);
	}
}
