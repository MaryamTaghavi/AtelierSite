using Atelier.Application.Helpers;
using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.CitiesDto;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;
using Atelier.Domain.Interfaces.IBaseInfoRepository;
using Atelier.Domain.Models.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Services.BaseInfoServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepositrory _userRepositrory;

        public UserService(IUserRepositrory repositrory)
        {
            _userRepositrory = repositrory;
        }


        public List<User> GetAll()
        {
            return _userRepositrory
                .GetAll();
        }

        public User GetById(int id)
        {
	        return _userRepositrory.GetById(id);
        }

		public UserDto GetByIdUserDto(int id)
		{
			return _userRepositrory.GetByIdUserDto(id);
		}

		public User LoginUser(LoginDto loginDto)
        {
            //has

            return _userRepositrory.LoginUser(loginDto);
        }

		public RequestResult Add(RegisterDto registerDto)
		{
			User user = new User()
			{
				CreateDate = DateTime.Now,
				FullName = registerDto.FullName,
				Title = registerDto.UserName,
				PhoneNumber = registerDto.PhoneNumber,
				Password = PasswordHelper.EncodePasswordMd5(registerDto.Password),
			};
			_userRepositrory.Add(user);

			return new RequestResult(true, statusCode: RequestResultStatusCode.Success);
		}

		public RequestResult Delete(int id)
		{
			throw new NotImplementedException();
		}
        public void UpdateDto(UserDto userDto)
		{
            var user = _userRepositrory.GetById(userDto.Id);
			user.Title = userDto.UserName;
			user.FullName =userDto.FullName;
			user.Password = PasswordHelper.EncodePasswordMd5(userDto.Password);
			user.PhoneNumber = userDto.PhoneNumber;

			Update(user);
		}

		public void Update(User user)
		{
			user.EditedDate = DateTime.Now;
			_userRepositrory.Update(user);
		}
	}
}
