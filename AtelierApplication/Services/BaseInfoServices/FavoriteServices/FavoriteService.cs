using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Interfaces.IBaseInfoServices.IFavoriteServices;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IFavoritesRepository;
using Atelier.Domain.Models.BaseInfo.Favorites;

namespace Atelier.Application.Services.BaseInfoServices.FavoriteServices
{
	public class FavoriteService : IFavoriteService
	{
		private readonly IFavoriteRepository _favoriteRepository;

		public FavoriteService(IFavoriteRepository favoriteRepository)
		{
			_favoriteRepository = favoriteRepository;
		}

		public List<AtelierShowViewModel> GetFavoriteByUserId(int id)
		{
			return _favoriteRepository.GetFavoriteByUserId(id);
		}

		public bool IsExistFavorite(int atelierId, int userId)
		{
			return _favoriteRepository.IsExistFavorite(atelierId, userId);
		}


		public bool AddOrDelete(int atelierId, int userId)
		{
			if (IsExistFavorite(atelierId, userId))
			{
				_favoriteRepository.Delete(atelierId, userId);
				return false;
			}
			_favoriteRepository.Add(new Favorite() { AtelierId = atelierId, UserId = userId });
			return true;
		}
	}
}
