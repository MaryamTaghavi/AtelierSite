﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.WorkSamplesDTOs;
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


		public List<AtelierShowViewModel> GetAllAteliers(int userId)
		{
			var result = _context.Ateliers
				.Include(x => x.AtelierGroups)
				.Include(x => x.Favorites)
				.Select(r => new AtelierShowViewModel()
				{
					Id = r.Id,
					Title = r.Title,
					City = r.City.Title,
					Logo = r.Logo,
					Banner = r.Banner,
					Address = r.Address,
					Instagram = r.Instagram,
					IsUserLiked = r.Favorites.Any(f=> f.UserId ==  userId),
					Phone = r.Phone,
					GroupingTitles = r.AtelierGroups.Select(g => g.Grouping.Title).ToList()
				}).ToList();

			result.ForEach(r => r.GroupingTitle = r.GroupingTitles.Aggregate((z, y) => z + " , " + y));

			return result;
		}

		public Domain.Models.BaseInfo.Ateliers.Atelier GetById(int id)
		{
			return _context.Ateliers.Find(id);
		}
		public AtelierShowViewModel GetAtelierById(int id)
		{
			var result = _context.Ateliers
				.Include(x => x.AtelierGroups)
				.Include(x => x.WorkSamples)
				.ThenInclude(x=> x.Grouping)
				.Include(x => x.Photographers)
				.Where(r => r.Id == id).Select(x => new AtelierShowViewModel()
				{
					Id = x.Id,
					Title = x.Title,
					Banner = x.Banner,
					Logo = x.Logo,
					Address = x.Address,
					Phone = x.Phone,
					Instagram = x.Instagram,
					City = x.City.Title,
					GroupingTitles =x.AtelierGroups.Select(g => g.Grouping.Title).ToList(),
					Photographers = x.Photographers.Select(p=> p.FullName).ToList(),
					WorkSamples = x.WorkSamples.ToList()

					//GroupingTitle = x.AtelierGroups.Select(g => g.Grouping.Title).ToList().Aggregate((z, y) => z + " , " + y)
				}).Single();
			result.Photographer = result.Photographers.Aggregate((z, y) => z + " , " + y);
			result.GroupingTitle = result.GroupingTitles.Aggregate((z, y) => z + " , " + y) ;
			return result;
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
