using Atelier.Domain.Models.BaseInfo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Atelier.Application.Security;
using Atelier.Domain.DTOs.BaseInfoDTOs.AccountDTOs;

namespace Atelier.Data.Seeder
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        // کاربر
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>()
            {
                new User(){
                    Id = 1,
                    UserName = "Admin",
                    Password = PasswordHelper.EncodePasswordMd5("123456"),
                  FullName = "فاطمه جعفری",
                  CreateDate = new DateTime(2023, 8, 1, 15, 21, 32, 968, DateTimeKind.Local).AddTicks(1379),
                  PhoneNumber = "09130023409",
                  TypeUser = TypeUser.Admin

                }
            });
        }
    }
}