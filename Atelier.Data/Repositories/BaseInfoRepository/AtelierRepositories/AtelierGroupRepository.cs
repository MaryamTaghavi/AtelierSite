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

		public List<AtelierSearchResultDto> SearchAtelier(SearchDto dto)
		{
			var result = _context.AtelierGroups
				.Include(r => r.Atelier).ThenInclude(r => r.city).AsQueryable();

			if (!string.IsNullOrEmpty(dto.Title))
			{
				result = result.Where(r => r.Atelier.Title.Contains(dto.Title));
			}

			if (dto.GroupingId > 0)
			{
				result = result.Where(r => r.GroupId == dto.GroupingId);
			}

			if (dto.CityId > 0)
			{
				result = result.Where(r => r.Atelier.CityId == dto.CityId);
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
