using Microsoft.EntityFrameworkCore;
using Persist;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddCustomServices();

            services.AddOpenApiDocument();
            // Configuration de la chaîne de connexion
            //string connectionString = "Server=localhost;Port=8081;User=root;Password=;Database=testntier" ;
            string connectionString = "Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8";

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=> {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey= new SymmetricSecurityKey( Encoding.ASCII.GetBytes("ayuidajhkcxewbyryebbbefgrkdwdzwyhhammygfgisnnweocdskgvgikvmtqpccmjihjggvdkrvcugqelerpfglbqypgfunddgggrhcpdbaiwopcpftgjfiopgxruas")),
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            });
            // Ajout du contexte de base de données
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.MaxDepth = 0;
                }
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUI();

            app.UseRouting();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
