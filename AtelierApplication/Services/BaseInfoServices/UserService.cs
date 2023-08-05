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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public List<User> GetAll()
        {
            return _userRepository
                .GetAll();
        }

        public User GetById(int id)
        {
	        return _userRepository.GetById(id);
        }

		public UserViewModel GetByIdUserDto(int id)
		{
			return _userRepository.GetByIdUserDto(id);
		}

		public User LoginUser(LoginViewModel loginViewModel,TypeUser typeUser)
        {
            return _userRepository.LoginUser(loginViewModel,typeUser);
        }

		public RequestResult Add(RegisterViewModel registerViewModel,TypeUser typeUser)
		{

			if(_userRepository.IsExist(registerViewModel.UserName.Trim(),typeUser))
                return new RequestResult(false, statusCode: RequestResultStatusCode.Conflict,"نام کاربری صحیح نمی باشد");


            User user = new User()
			{
				CreateDate = DateTime.Now,
				FullName = registerViewModel.FullName,
				UserName = registerViewModel.UserName.Trim(),
				PhoneNumber = registerViewModel.PhoneNumber,
				Password = PasswordHelper.EncodePasswordMd5(registerViewModel.Password),
				TypeUser = typeUser
			};
			_userRepository.Add(user);

			return new RequestResult(true, statusCode: RequestResultStatusCode.Success);
		}

		public RequestResult Delete(int id)
		{
			throw new NotImplementedException();
		}

        public void UpdateDto(UserViewModel userViewModel)
		{
            var user = _userRepository.GetById(userViewModel.Id);
			user.UserName = userViewModel.UserName;
			user.FullName =userViewModel.FullName;
			user.Password = PasswordHelper.EncodePasswordMd5(userViewModel.Password);
			user.PhoneNumber = userViewModel.PhoneNumber;

			Update(user);
		}

		public void Update(User user)
		{
			user.EditedDate = DateTime.Now;
			_userRepository.Update(user);
		}
	}
}
