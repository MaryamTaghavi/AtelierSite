using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices.IPhotographersService;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IPhotographersRepository;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Atelier.Domain.Models.BaseInfo.Photographers;

namespace Atelier.Application.Services.BaseInfoServices.PhotographersService
{
    public class PhotographerService : IPhotographerService
    {
        private readonly IPhotographerRepository _photographerRepository;

        public PhotographerService(IPhotographerRepository photographerRepository)
        {
            _photographerRepository = photographerRepository;
        }

       
        public List<Photographer> GetAll()
        {
            return _photographerRepository.GetAll();
        }

        public List<PhotographersShowViewModel> GetAllPhotographer(int atelierId)
        {
            return _photographerRepository.GetAllPhotographers(atelierId);
        }

        public Photographer GetById(int id)
        {
            return _photographerRepository.GetById(id);
        }

        public PhotographersViewModel GetByIdPhotographerViewModel(int id)
        {
            return _photographerRepository.GetByIdPhotographerViewModel(id);
        }

        public void Add(PhotographersViewModel photographersViewModel)
        {
            Photographer photographer = new Photographer()
            {
                FullName = photographersViewModel.FullName,
                AtelierId = photographersViewModel.AtelierId,
            };
            _photographerRepository.Add(photographer);
        }

        public void Update(Photographer photographer)
        {
            photographer.EditedDate = DateTime.Now;
            _photographerRepository.Update(photographer);
        }

        public void UpdateDto(PhotographersViewModel photographersViewModel)
        {
            var photographer = GetById(photographersViewModel.Id);

            photographer.FullName = photographersViewModel.FullName;
            Update(photographer);
        }
        
        public RequestResult Delete(int id)
        {
            var photographer = GetById(id);

            photographer.DeletedDate = DateTime.Now;

            Update(photographer);

            return new RequestResult(true, RequestResultStatusCode.Success, "عکاس با موفقیت حذف شد.");
        }
    }
}
