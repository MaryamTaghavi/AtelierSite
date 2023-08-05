using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.Models.BaseInfo.Photographers;

namespace Atelier.Application.Interfaces.IBaseInfoServices.IPhotographersService
{
    public interface IPhotographerService
    {
        List<Photographer> GetAll();
        List<PhotographersShowViewModel> GetAllPhotographer(int atelierId);
        Photographer GetById(int id);

        PhotographersViewModel GetByIdPhotographerViewModel(int id);
        void Add(PhotographersViewModel photographersViewModel);
        RequestResult Delete(int id);
        void Update(Photographer photographer);
        void UpdateDto(PhotographersViewModel photographersViewModel);
    }
}
