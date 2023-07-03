using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;
using Atelier.Domain.Models.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Interfaces.IBaseInfoRepository
{
    public interface IUserRepositrory
    {
        List<User> GetAll();

        User GetById(int id);
        void Add(User user);
        User LoginUser(LoginDto loginDto);
        void Delete(int id);
        void Update(User user);


    }
}
