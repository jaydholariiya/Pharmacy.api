using Pharmacy.Common.Api.Infrastructure.AutoMapper;
using Pharmacy.Common.Api.DependencyInjection;
using Pharmacy.Common.Api.Middleware;
using Pharmacy.Common.Database.DbModels;
using Pharmacy.Common.Util.Security.JsonWebToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;


namespace Pharmacy.Common.Api.Infrastructure.Extensions
{
    public static class Application
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services)
        {
            DependencyInjector.RegisterServices(services);
        }

        public static void AddLoggerCustom(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        public static void AddAuthenticationCustom(this IServiceCollection services)
        {
            var jsonWebToken = DependencyInjector.GetService<IJsonWebToken>();

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;
            }
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddDatabase(this IConfiguration configuration)
        {
            DependencyInjector.AddDbContext<PharmacyContext>(configuration["AppSettings:ConnectionString"]);
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(Program));
        }

        public static void AddCorsCustom(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public static void UseCorsCustom(this IApplicationBuilder app)
        {
            app.UseCors("MyPolicy");
        }

        public static void AddCustomFilters(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(Pharmacy.Common.Api.Infrastructure.Attributes.ValidateModelAttribute)));
        }

    

        public static void ConfigureSwaggerUI(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(configuration["SwaggerUrl"], "Pharmacy.Common Web API v1.0");
                c.DocumentTitle = "Pharmacy.Common Web API";
                c.DocExpansion(DocExpansion.None);
            });
        }

        public static void AddSwaggerUICustom(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Pharmacy.Common",
                    Description = "Pharmacy.Common API version 1.0"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
                });
            });
        }
    }
}