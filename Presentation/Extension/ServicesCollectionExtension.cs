using Persist;
using Services;
using Repositories;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IServiceBook, ServiceBook>();

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
        
        services.AddScoped<IErrorRepository,ErrorRepository>();
        services.AddScoped<IErrorService,ErrorService>();
        
        return services;
    }
}
