﻿using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Application.Services.BaseInfoServices;
using Atelier.Application.Services.BaseInfoServices.AtelierServices;
using Atelier.Application.Services.BaseInfoServices.CitiesServices;
using Atelier.Application.Services.BaseInfoServices.GroupingServices;
using Atelier.Data.Repositories.BaseInfoRepository;
using Atelier.Data.Repositories.BaseInfoRepository.AtelierRepositories;
using Atelier.Data.Repositories.BaseInfoRepository.CitiesRepositories;
using Atelier.Data.Repositories.BaseInfoRepository.GroupingRepositories;
using Atelier.Domain.Interfaces.IBaseInfoRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {

            //Application Layer
            // service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IGroupingService, GroupingService>();
			service.AddScoped<ICityService, CityService>();
			service.AddScoped<IAtelierService, AtelierService>();
			service.AddScoped<IAtelierGroupService, AtelierGroupService>();


			//Infra Data Layer
			//  service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IUserRepositrory, UserRepository>();
			service.AddScoped<IGroupingRepository, GroupingRepository>();
			service.AddScoped<ICityRepository, CityRepository>();
			service.AddScoped<IAtelierRepository, AtelierRepository>();
			service.AddScoped<IAtelierGroupRepository, AtelierGroupRepository>();


        }
    }
}
