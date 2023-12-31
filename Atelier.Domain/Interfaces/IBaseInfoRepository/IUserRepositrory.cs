﻿using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atelier.Domain.DTOs.BaseInfoDTOs.UsersDTOs;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository
{
    public interface IUserRepositrory
    {
        List<User> GetAll();

        User GetById(int id);
        UserViewModel GetByIdUserDto(int id);
		void Add(User user);
        User LoginUser(LoginViewModel loginViewModel);
        void Update(User user);


    }
}
