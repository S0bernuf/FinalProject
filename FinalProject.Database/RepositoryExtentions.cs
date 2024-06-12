using FinalProject.Database.Repositories.Interfaces;
using FinalProject.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Database
{
    public static class RepositoryExtensions
    {
        // Praita karta nepavyko iskviesti, reikia paziureti kas negerai
        /*
         * 1. All fine, added example in comments in Program.cs
         * 2. Naming conventions, check if entered correctly: for Example RepositoryExtentions should be RepositoryExtensions
         * 3. OPTIONAL: AddDatabase naming could be better, for ex.: RegisterRepositories
         * 4. you do not need this : services.AddDbContext<FinalProjectDbContext>(options => options.UseSqlServer(connectionString)); - DONE
         * you defining this in Program.cs
         * 5. return services; is not needed anymore because of (this IServiceCollection services) ,,,,this,,,, keyword
         */
        public static void RegisterRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();


        }
    }
}
