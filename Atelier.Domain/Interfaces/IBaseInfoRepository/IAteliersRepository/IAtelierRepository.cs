using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.Models.BaseInfo.Cities;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository
{
	public interface IAtelierRepository
	{
		List<AtelierShowViewModel> GetAllAteliers(int userId);
		AtelierShowViewModel GetAtelierById(int id);
		Models.BaseInfo.Ateliers.Atelier GetById(int id);
		AtelierViewModel GetByIdAtelierViewModel(int id);
		void Add(Models.BaseInfo.Ateliers.Atelier atelier);
		void Update(Models.BaseInfo.Ateliers.Atelier atelier);
	}
}
