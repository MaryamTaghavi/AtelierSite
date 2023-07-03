using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Data.Repositories.BaseInfoRepository.AtelierRepositories
{
	public class AtelierGroupRepository : IAtelierGroupRepository

	{
		private readonly AtelierContext _context;

		public AtelierGroupRepository(AtelierContext context)
		{
			_context = context;
		}

		public List<AtelierGroup> GetAll()
		{
			return _context.AtelierGroups.ToList();
		}

		public List<AtelierSearchResultDto> SearchAtelier(string atelierName, int groupId, int cityId)
		{
			var result = _context.AtelierGroups
				.Include(r => r.Atelier).ThenInclude(r => r.city).AsQueryable();

			if (!string.IsNullOrEmpty(atelierName))
			{
				result = result.Where(r => r.Atelier.Title.Contains(atelierName));
			}

			if (groupId > 0)
			{
				result = result.Where(r => r.GroupId == groupId);
			}

			if (cityId > 0)
			{
				result = result.Where(r => r.Atelier.CityId == cityId);
			}

			var list = result.ToList();
			return list.Select(r => new AtelierSearchResultDto()
			{
				Title = r.Atelier.Title,
				Banner = r.Atelier.Banner,
				Id = r.AtelierId,
				Logo = r.Atelier.Logo,
				cityTitle = r.Atelier.city.Tilte
			}).ToList();
		}
	}
}
