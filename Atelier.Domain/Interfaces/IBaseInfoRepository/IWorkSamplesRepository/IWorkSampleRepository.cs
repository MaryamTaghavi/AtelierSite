using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Atelier.Domain.Models.BaseInfo.WorkSamples;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IWorkSamplesRepository
{
	public interface IWorkSampleRepository
	{
		List<WorkSample> GetAll();
		List<WorkSampleShowViewModel> GetAllWorkSample(int atelierId);
		WorkSample GetById(int id);
		WorkSampleViewModel GetByIdWorkSampleViewModel(int id);
		void Add(WorkSample workSample);
		void Update(WorkSample workSample);
	}
}
