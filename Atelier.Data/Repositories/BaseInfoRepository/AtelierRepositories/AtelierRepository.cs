using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Data.Repositories.BaseInfoRepository.AtelierRepositories
{
	public class AtelierRepository : IAtelierRepository
	{
		private readonly AtelierContext _context;

		public AtelierRepository(AtelierContext context)
		{
			_context = context;
		}

	
		public List<AtelierShowViewModel> GetAllAteliers()
		{
			return _context.Ateliers.Select(r => new AtelierShowViewModel()
			{
				Id	= r.Id,
				Title = r.Title,
				City =r.City.Title,
				Logo = r.Logo
			}).ToList();
		}

		public Domain.Models.BaseInfo.Ateliers.Atelier GetById(int id)
		{
			return _context.Ateliers.Find(id);
		}

		public AtelierViewModel GetByIdAtelierViewModel(int id)
		{
			return _context.Ateliers
				.Include(x=> x.AtelierGroups)
				.Where(r => r.Id == id).Select(x => new AtelierViewModel()
			{
				Id = x.Id,
				Title = x.Title,
				Address = x.Address,
				Phone = x.Phone,
				Instagram = x.Instagram,
				CityId = x.CityId,
				GroupingIds = x.AtelierGroups.Select(g=> g.GroupId).ToList()
			}).SingleOrDefault();
		}

		public void Add(Domain.Models.BaseInfo.Ateliers.Atelier atelier)
		{
			_context.Ateliers.Add(atelier);
			_context.SaveChanges();
		}

		public void Update(Domain.Models.BaseInfo.Ateliers.Atelier atelier)
		{
			_context.Ateliers.Update(atelier);
			_context.SaveChanges();
		}
	}
}
