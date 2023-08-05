using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.Models.BaseInfo.Photographers;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository.IPhotographersRepository
{
    public interface IPhotographerRepository
    {
        List<Photographer> GetAll();
        List<PhotographersShowViewModel> GetAllPhotographers(int atelierId);
        Photographer GetById(int id);
        PhotographersViewModel GetByIdPhotographerViewModel(int id);
        void Add(Photographer photographer);
        void Update(Photographer photographer);
    }
}
