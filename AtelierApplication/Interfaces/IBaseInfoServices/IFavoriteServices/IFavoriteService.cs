using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.Models.BaseInfo.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IFavoriteServices
{
	public interface IFavoriteService
	{
		List<AtelierShowViewModel> GetFavoriteByUserId(int id);
		bool IsExistFavorite(int atelierId, int userId);
		bool AddOrDelete(int atelierId,int userId);
	}
}
