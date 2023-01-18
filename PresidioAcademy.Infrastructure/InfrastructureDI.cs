using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Infrastructure.DbContext;
using PresidioAcademy.Infrastructure.Repositories;

namespace PresidioAcademy.Infrastructure;

public static class InfrastructureDI
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configurations)
    {
        // Add DbContext
        services.AddDbContext<PresidioAcademyContext>(opt=> opt.UseSqlServer(configurations.GetConnectionString("SSMS-DB"),
            b=>b.MigrationsAssembly(typeof(PresidioAcademyContext).Assembly.FullName)), ServiceLifetime.Transient);
        services.AddScoped<IPresidioAcademyContext>(provider => provider.GetService<PresidioAcademyContext>());
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IAssetRepository, AssetRepository>();

        services.AddScoped<IADOContext,ADOContext>();
        return services;
    }
}