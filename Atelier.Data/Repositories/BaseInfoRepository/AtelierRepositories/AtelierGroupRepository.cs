using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierGroupDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.SearchDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Models.BaseInfo;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> GetAllAtelierGroupByAtelierId(int atelierId)
        {

			return _context.AtelierGroups.Include(x => x.Grouping)
                .Where(x => x.AtelierId == atelierId)
                .Select(x => new SelectListItem()
			        {
                        Text = x.Grouping.Title,
                        Value = x.GroupId.ToString()
                }).ToList();
		}

        public void DeleteAllAtelierGroup(int atelierId)
        {
			var result = _context.AtelierGroups.Where(r => r.AtelierId == atelierId);
			_context.AtelierGroups.RemoveRange(result);
			_context.SaveChanges();
		}

        public void AddRangeOAtelierGroup(List<AtelierGroup> list)
        {
			_context.AddRange(list);
			_context.SaveChanges();
		}

        public List<AtelierShowViewModel> SearchAtelier(SearchViewModel viewModel)
		{
			var result = _context.AtelierGroups
				.Include(r => r.Grouping)
				.Include(r => r.Atelier.City)
				.Include(x=> x.Atelier)
				.ThenInclude(r => r.Favorites).AsQueryable();

			if (!string.IsNullOrEmpty(viewModel.Title))
				result = result.Where(r => r.Atelier.Title.Contains(viewModel.Title));
			

			if (viewModel.GroupingId !=0)
				result = result.Where(r => r.GroupId == viewModel.GroupingId);
			
			if (viewModel.CityId !=0)
				result = result.Where(r => r.Atelier.CityId == viewModel.CityId);

			var res = result.AsEnumerable().GroupBy(x=> x.AtelierId).Select(r => new AtelierShowViewModel()
			{
				Title = r.FirstOrDefault()?.Atelier.Title,
				Banner = r.FirstOrDefault()?.Atelier.Banner,
				AtelierId =r.Key,
				IsUserLiked = r.FirstOrDefault()?.Atelier.Favorites.Any(f => f.UserId == viewModel.UserId)??false,
				Logo = r.FirstOrDefault()?.Atelier.Logo,
				City = r.FirstOrDefault()?.Atelier.City.Title,
				Address = r.FirstOrDefault()?.Atelier.Address,
				Phone = r.FirstOrDefault()?.Atelier.Phone,
				Instagram = r.FirstOrDefault()?.Atelier.Instagram,
				GroupingTitle = string.Join(",", r.Select(g => g.Grouping.Title).ToList()),

			}).ToList();

			//دستور پایین هرجا Aggreate استفاده کردت خرابه 
			//مثل این درست کند 					Photographer = string.Join(",", x.Photographers.Select(g=> g.FullName).ToList()),

			return res;
		}

        public List<AtelierShowViewModel> FilterAtelier(List<int> groupIds, List<int> cityIds)
        {

	        var result = _context.AtelierGroups
		        .Include(r => r.Grouping)
		        .Include(r => r.Atelier.City).AsQueryable();


	        if (groupIds .Count!= 0)
		        result = result.Where(r => groupIds.Contains(r.GroupId));

	        if (cityIds.Count != 0)
		        result = result.Where(r => cityIds.Contains(r.Atelier.CityId));

	        var res = result.AsEnumerable().GroupBy(x => x.AtelierId).Select(r => new AtelierShowViewModel()
	        {
		        Title = r.FirstOrDefault()?.Atelier.Title,
		        Banner = r.FirstOrDefault()?.Atelier.Banner,
		        AtelierId = r.Key,
		        Logo = r.FirstOrDefault()?.Atelier.Logo,
		        City = r.FirstOrDefault()?.Atelier.City.Title,
		        Address = r.FirstOrDefault()?.Atelier.Address,
		        Phone = r.FirstOrDefault()?.Atelier.Phone,
		        Instagram = r.FirstOrDefault()?.Atelier.Instagram,
		        GroupingTitle = string.Join(",", r.Select(g => g.Grouping.Title).ToList()),
		       // GroupingTitles = r.ToList().Select(g => g.Grouping.Title).ToList().Aggregate((x, y) => x + " , " + y)
			}).ToList();
	        return res;
        }
	}
}
