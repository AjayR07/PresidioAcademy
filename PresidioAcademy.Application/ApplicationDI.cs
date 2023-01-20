using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Application.Services;

namespace PresidioAcademy.Application;

public static class ApplicationDI
{
    public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configurations)
    {
        services.AddScoped<IEmployeeService,EmployeeService>();
        services.AddScoped<IAssetService,AssetService>();
        services.AddScoped<ILoginService, LoginService>();

        return services;
    }
}