using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.DTOs.BaseInfoDTOs.GroupingDtos;
using Atelier.Domain.Models.BaseInfo;
using Atelier.Domain.Models.BaseInfo.Groupings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;

namespace Atelier.Application.Interfaces.IBaseInfoServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        UserViewModel GetByIdUserDto(int id);
		RequestResult Add(RegisterViewModel registerViewModel, TypeUser typeUser);
        User LoginUser(LoginViewModel loginViewModel,TypeUser typeUser);
        RequestResult Delete(int id);
		void Update(User user);
		void UpdateDto(UserViewModel userViewModel);
	}
}
