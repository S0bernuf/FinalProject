using FinalProject.Database.Repositories.Interfaces;
using FinalProject.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Database
{
    public static class RepositoryExtentions
    {
        // Praita karta nepavyko iskviesti, reikia paziureti kas negerai
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<FinalProjectDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;


        }
    }
}
