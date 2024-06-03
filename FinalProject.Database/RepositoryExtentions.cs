using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Database
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FinalProjectDbContext>(options => options.UseSqlServer(connectionString));

            return services;

        }
    }
}
