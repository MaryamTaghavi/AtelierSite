

using Microsoft.Extensions.DependencyInjection;

namespace Atelier.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
           // service.AddScoped<IUserService, UserService>();
         


            //Infra Data Layer
          //  service.AddScoped<IUserRepository, UserRepository>();
          

        }
    }
}
