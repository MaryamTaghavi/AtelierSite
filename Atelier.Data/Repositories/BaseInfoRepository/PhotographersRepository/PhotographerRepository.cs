using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.PhotographerDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IPhotographersRepository;
using Atelier.Domain.Models.BaseInfo.Photographers;

namespace Atelier.Data.Repositories.BaseInfoRepository.PhotographersRepository
{
    public class PhotographerRepository : IPhotographerRepository
    {
        private readonly AtelierContext _context;

        public PhotographerRepository(AtelierContext context)
        {
            _context = context;
        }


        public List<Photographer> GetAll()
        {
            return _context.Photographers.ToList();
        }

        public List<PhotographersShowViewModel> GetAllPhotographers(int atelierId)
        {
            return _context.Photographers.Where(x=> x.AtelierId == atelierId).Select(r => new PhotographersShowViewModel()
            {
                Id = r.Id,
                FullName = r.FullName
            }).ToList();
        }

        public Photographer GetById(int id)
        {
            return _context.Photographers.Find(id);
        }

        public PhotographersViewModel GetByIdPhotographerViewModel(int id)
        {
            return _context.Photographers.Where(x => x.Id == id).Select(x => new PhotographersViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                AtelierId = x.AtelierId
            }).SingleOrDefault();
        }

        public void Add(Photographer photographer)
        {
            _context.Photographers.Add(photographer);
            _context.SaveChanges();
        }

        public void Update(Photographer photographer)
        {
            _context.Photographers.Update(photographer);
            _context.SaveChanges();
        }
    }
}
