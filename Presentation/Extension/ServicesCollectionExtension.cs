using Persist;
using Services;
using Repositories;
using Microsoft.AspNetCore.Identity;
using Services.Models.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IServerRepository, ServerRepository>();
        services.AddScoped<IServerService, ServerServices>();

        services.AddScoped<ICustomerHaveLicenceToApplicationRepository, CustomerHaveLicenceToApplicationRepository>();
        services.AddScoped<ICustomerHaveLicenceToService, CustomerHaveLicenceToApplicationService>();

        services.AddScoped<IApplicationDeployedOnServerRepository, ApplicationDeployedOnServerRepository>();
        services.AddScoped<IApplicationDeployedOnServerService, ApplicationDeployedOnServerService>();

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IApplicationService, ApplicationService>();

        services.AddScoped<IErrorRepository, ErrorRepository>();
        services.AddScoped<IErrorService, ErrorService>();

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IPasswordHasherService,PasswordHasherService>();
        return services;
    }
}