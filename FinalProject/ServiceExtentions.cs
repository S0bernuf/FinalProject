using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using FinalProject.BusinessLogic.MappingProfiles;

namespace FinalProject.BusinessLogic
{
    public static class ServiceExtentions
    {
        
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddAutoMapper(typeof(MappingProfile));


        }


    }
}
