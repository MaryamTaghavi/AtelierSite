using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IFavoritesRepository;
using Atelier.Domain.Models.BaseInfo.Favorites;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Data.Repositories.BaseInfoRepository.FavoriteRepository
{
	public class FavoriteRepository : IFavoriteRepository
	{
		private readonly AtelierContext _context;

		public FavoriteRepository(AtelierContext context)
		{
			_context = context;
		}

		public List<AtelierShowViewModel> GetFavoriteByUserId(int userId)
		{
			return _context.Favorites
				.Include(r => r.Atelier)
				.ThenInclude(r => r.AtelierGroups)
				.ThenInclude(r => r.Grouping)
				.Include(r => r.User)
				.Where(x => x.UserId == userId).Select(r => new AtelierShowViewModel()
				{
					Title = r.Atelier.Title,
					Banner = r.Atelier.Banner,
					AtelierId = r.AtelierId,
					IsUserLiked = r.UserId == userId,
					Logo = r.Atelier.Logo,
					City = r.Atelier.City.Title,
					GroupingTitle = string.Join(",",r.Atelier.AtelierGroups.Select(g => g.Grouping.Title).ToList()),
				})
				.ToList();
		}

		public void Delete(int atelierId, int userId)
		{
			var favorite = _context.Favorites.SingleOrDefault(x => x.AtelierId == atelierId && x.UserId == userId);

			if (favorite == null) return;
			_context.Remove(favorite);
			_context.SaveChanges();
		}

		public void Add(Favorite favorite)
		{
			_context.Favorites.Add(favorite);
			_context.SaveChanges();
		}

		public bool IsExistFavorite(int atelierId, int userId)
		{
			return _context.Favorites.Any(x => x.AtelierId == atelierId && x.UserId == userId);
		}
	}
}
