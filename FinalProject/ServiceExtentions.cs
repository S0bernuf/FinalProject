using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic
{
    public static class ServiceExtentions
    {
        
            public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
            {
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IPersonService, PersonService>();

                //services.AddScoped<ITokenService, TokenService>();
                return services;
            }

        
    }
}
