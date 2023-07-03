using Atelier.Application.Security;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository;
using Atelier.Domain.Models.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Data.Repositories.BaseInfoRepository
{
    public class UserRepository : IUserRepositrory
    {
        private readonly AtelierContext _context;

        public UserRepository(AtelierContext context)
        {
            _context = context;
        }


        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(LoginDto loginDto)
        {
            var pass = PasswordHelper.EncodePasswordMd5(loginDto.Password);
            return _context.Users.SingleOrDefault(r => r.Title == loginDto.UserName && r.Password  == pass);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
