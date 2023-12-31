﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Application.Utilities;
using Atelier.Domain.DTOs.BaseInfoDTOs.AtelierDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Models.BaseInfo.Ateliers;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Atelier = Atelier.Domain.Models.BaseInfo.Ateliers.Atelier;

namespace Atelier.Application.Services.BaseInfoServices.AtelierServices
{
	public class AtelierService : IAtelierService
	{
		private readonly IAtelierRepository _atelierRepository;

		public AtelierService(IAtelierRepository atelierRepository)
		{
			_atelierRepository = atelierRepository;
		}


		public void Add(AtelierViewModel atelierViewModel)
		{
			var logoNameAddress = atelierViewModel.Logo.SaveFile("images\\LogoImages\\");
			var bannerNameAddress = atelierViewModel.Banner.SaveFile("images\\BannerImages\\");

		var atelier = new Domain.Models.BaseInfo.Ateliers.Atelier()
			{
				Title = atelierViewModel.Title,
				Address = atelierViewModel.Address,
				Logo = logoNameAddress,
				Banner = bannerNameAddress,
				Instagram = atelierViewModel.Instagram,
				CityId = atelierViewModel.CityId,
				UserId = atelierViewModel.UserId,
				AtelierGroups = atelierViewModel.GroupingIds?.Select(r => new AtelierGroup()
				{
					GroupId = r
				}).ToList()
				
			};
			_atelierRepository.Add(atelier);
		}

		public RequestResult Delete(int id)
		{
			var atelier = GetById(id);
			atelier.DeletedDate = DateTime.Now;
			Update(atelier);
			return new RequestResult(true, RequestResultStatusCode.Success, "آتلیه با موفقیت حذف شد.");
		}

		public List<AtelierShowViewModel> GetAllAteliers()
		{
			return _atelierRepository.GetAllAteliers();
		}

		public Domain.Models.BaseInfo.Ateliers.Atelier GetById(int id)
		{
			return _atelierRepository.GetById(id);
		}

		public AtelierViewModel GetByIdAtelierViewModel(int id)
		{
			return _atelierRepository.GetByIdAtelierViewModel(id);
		}

		public void Update(Domain.Models.BaseInfo.Ateliers.Atelier atelier)
		{
			atelier.EditedDate = DateTime.Now;
			_atelierRepository.Update(atelier);
		}

		public void UpdateDto(AtelierViewModel atelierViewModel)
		{
			var atelier = GetById(atelierViewModel.Id);

			if (atelierViewModel.Logo != null)
			{
				atelier.Logo.DeleteFile();
				var logoNameAddress = atelierViewModel.Logo.SaveFile("images\\LogoImages\\");
				atelier.Logo = logoNameAddress;

			}
			atelier.Title = atelierViewModel.Title;
			Update(atelier);
		}
	}
}
