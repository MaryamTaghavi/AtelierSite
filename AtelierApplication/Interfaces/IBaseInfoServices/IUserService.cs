using Atelier.Application.Helpers;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Interfaces.IBaseInfoServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);

        RequestResult Add(RegisterDto registerDto);
        User LoginUser(LoginDto loginDto);
        RequestResult Delete(int id);
        RequestResult Update(User user);
    }
}
