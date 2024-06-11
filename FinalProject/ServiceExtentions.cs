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
        // Praita karta nepavyko iskviesti, reikia paziureti kas negerai
        /*
         * 1. All fine, added example in comments in Program.cs
         * 2. Naming conventions, check if entered correctly: for Example ServiceExtentions should be ServiceExtensions
         * 3. OPTIONAL: AddBusinessLogicServices naming could be better, for ex.: RegisterServices
         * 4. Do not forget to inject services.AddScoped<IPersonService,PersonService>();
         * 5. You can move this :  builder.Services.AddAutoMapper(typeof(MappingProfile)); over there (as mentioned in Program.cs comments)
         * 6. return services; is not needed anymore because of (this IServiceCollection services) ,,,,this,,,, keyword
         * 7. remove not used usings
         */
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }


    }
}
