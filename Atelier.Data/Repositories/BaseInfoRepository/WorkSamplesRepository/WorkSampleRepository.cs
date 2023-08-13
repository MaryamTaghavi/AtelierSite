using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IWorkSamplesRepository;
using Atelier.Domain.Models.BaseInfo.WorkSamples;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Data.Repositories.BaseInfoRepository.WorkSamplesRepository
{
	public class WorkSampleRepository : IWorkSampleRepository
	{
		private readonly AtelierContext _context;

		public WorkSampleRepository(AtelierContext context)
		{
			_context = context;
		}

		
		public List<WorkSample> GetAll()
		{
			return _context.WorkSamples.ToList();
		}

		public List<WorkSampleShowViewModel> GetAllWorkSample(int atelierId)
		{
			return _context.WorkSamples.Include(r => r.Grouping).Where(x => x.AtelierId == atelierId).Select(r => new WorkSampleShowViewModel()
			{
				Id = r.Id,
				WorkSamplePic = r.WorkSamplePic,
				GroupTitle = r.Grouping.Title
			}).ToList();
		}

		public WorkSample GetById(int id)
		{
			return _context.WorkSamples.Find(id);
		}

		public WorkSampleViewModel GetByIdWorkSampleViewModel(int id)
		{
			return _context.WorkSamples.Where(x => x.Id == id).Select(r => new WorkSampleViewModel()
			{
				Id = r.Id,
				//WorkSamplePic = r.WorkSamplePic,
				AtelierId = r.AtelierId,
				GroupId = r.GroupId
			}).SingleOrDefault();
		}

		public void Add(WorkSample workSample)
		{
			_context.WorkSamples.Add(workSample);
			_context.SaveChanges();
		}

		public void Update(WorkSample workSample)
		{
			_context.WorkSamples.Update(workSample);
			_context.SaveChanges();
		}
	}
}
