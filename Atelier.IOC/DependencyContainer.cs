using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IAtelierServices;
using Atelier.Application.Interfaces.IBaseInfoServices.ICitiesServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IFavoriteServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IGroupingServices;
using Atelier.Application.Interfaces.IBaseInfoServices.IPhotographersService;
using Atelier.Application.Interfaces.IBaseInfoServices.IWorkSamplesServices;
using Atelier.Application.Services.BaseInfoServices;
using Atelier.Application.Services.BaseInfoServices.AtelierServices;
using Atelier.Application.Services.BaseInfoServices.CitiesServices;
using Atelier.Application.Services.BaseInfoServices.FavoriteServices;
using Atelier.Application.Services.BaseInfoServices.GroupingServices;
using Atelier.Application.Services.BaseInfoServices.PhotographersService;
using Atelier.Application.Services.BaseInfoServices.WorkSamplesServices;
using Atelier.Data.Repositories.BaseInfoRepository;
using Atelier.Data.Repositories.BaseInfoRepository.AtelierRepositories;
using Atelier.Data.Repositories.BaseInfoRepository.CitiesRepositories;
using Atelier.Data.Repositories.BaseInfoRepository.FavoriteRepository;
using Atelier.Data.Repositories.BaseInfoRepository.GroupingRepositories;
using Atelier.Data.Repositories.BaseInfoRepository.PhotographersRepository;
using Atelier.Data.Repositories.BaseInfoRepository.WorkSamplesRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IAteliersRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.ICitiesRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IFavoritesRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IGropingRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IPhotographersRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository.IWorkSamplesRepository;
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
			service.AddScoped<IPhotographerService, PhotographerService>();
			service.AddScoped<IWorkSampleService, WorkSampleService>();
			service.AddScoped<IFavoriteService, FavoriteService>();


			//Infra Data Layer
			//  service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IGroupingRepository, GroupingRepository>();
			service.AddScoped<ICityRepository, CityRepository>();
			service.AddScoped<IAtelierRepository, AtelierRepository>();
			service.AddScoped<IAtelierGroupRepository, AtelierGroupRepository>();
			service.AddScoped<IPhotographerRepository, PhotographerRepository>();
			service.AddScoped<IWorkSampleRepository, WorkSampleRepository>();
			service.AddScoped<IFavoriteRepository, FavoriteRepository>();


        }
    }
}
