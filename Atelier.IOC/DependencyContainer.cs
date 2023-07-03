

using Atelier.Application.Interfaces.IBaseInfoServices;
using Atelier.Application.Services.BaseInfoServices;
using Atelier.Data.Repositories.BaseInfoRepository;
using Atelier.Domain.Interfaces.IBaseInfoRepository;
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


            //Infra Data Layer
            //  service.AddScoped<IUserRepository, UserRepository>();
                service.AddScoped<IUserRepositrory, UserRepository>();


        }
    }
}
