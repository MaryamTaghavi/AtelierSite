using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.Models.BaseInfo.Favorites;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IFavoritesRepository
{
	public interface IFavoriteRepository
	{
		List<AtelierShowViewModel> GetFavoriteByUserId(int userId);
		void Delete(int atelierId, int userId);
		void Add(Favorite favorite);
		bool IsExistFavorite(int atelierId, int userId);

	}
}
