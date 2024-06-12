using FinalProject.Database.Repositories.Interfaces;
using FinalProject.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Database
{
    public static class RepositoryExtensions
    {

        public static void RegisterRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();


        }
    }
}
