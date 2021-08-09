using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Guilherme.LojaVirtualApi.Repository
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LojaVirtualApiConnectionString"),action => action.MigrationsAssembly("Guilherme.LojaVirtualApi")));

            return services;
        }
    }
}
