using Atelier.Application.Security;
using Atelier.Data.Context;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;
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


        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
			return _context.Users.Find(id);
		}

		public UserDto GetByIdUserDto(int id)
		{
			return _context.Users.Where(x => x.Id == id).Select(r => new UserDto()
			{
				Id = r.Id,
				FullName = r.FullName,
				UserName = r.Title,
				Password = r.Password,
				PhoneNumber = r.PhoneNumber
			}).SingleOrDefault();
		}

		public User LoginUser(LoginDto loginDto)
        {
            var pass = PasswordHelper.EncodePasswordMd5(loginDto.Password);
            return _context.Users.SingleOrDefault(r => r.Title == loginDto.UserName && r.Password  == pass);
        }


		public void Add(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public void Update(User user)
        {
			_context.Users.Update(user);
			_context.SaveChanges();
		}


	}
}
