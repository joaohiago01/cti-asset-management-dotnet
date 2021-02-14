using CTI.Asset.Management.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CTI.Asset.Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddScoped<ApplicationContext>(provider => provider.GetService<ApplicationContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddAuthentication();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
    }
}