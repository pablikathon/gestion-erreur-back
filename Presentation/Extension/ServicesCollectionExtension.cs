using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

using Repositories;

using Ressources.Auth.Message;

using Services;
using Services.Models.Auth;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddCustomServices(this IServiceCollection services)
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

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ISecurityService, SecurityService>();
        return services;
    }
    internal static IServiceCollection AddSwaggerWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {

            c.CustomSchemaIds(Id => Id.FullName!.Replace('+', '-'));
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = SecuritySchemeConstant.Name,
                Description = SecuritySchemeConstant.Description,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = SecuritySchemeConstant.BearerFormat,
                Scheme = SecuritySchemeConstant.Scheme,
            };
            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new List<string>()

                }
            };
            c.AddSecurityRequirement(securityRequirement);
        });
        return services;
    }
}
