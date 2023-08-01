using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices
{
	public interface IAtelierService
	{
		List<AtelierShowViewModel> GetAllAteliers();
		Domain.Models.BaseInfo.Ateliers.Atelier GetById(int id);
		AtelierViewModel GetByIdAtelierViewModel(int id);
		void Add(AtelierViewModel atelierViewModel);
		void Update(Domain.Models.BaseInfo.Ateliers.Atelier atelier);
		void UpdateDto(AtelierViewModel atelierViewModel);
		RequestResult Delete(int id);
	}
}
