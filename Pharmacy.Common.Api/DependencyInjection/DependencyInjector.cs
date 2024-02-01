using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Common.Util.Security.JsonWebToken;

namespace Pharmacy.Common.Api.DependencyInjection
{
    public class DependencyInjector
    {
        private static IServiceProvider? ServiceProvider { get; set; }

        private static IServiceCollection? Services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            Services!.AddDbContext<T>(options => options.UseNpgsql(connectionString));
        }

        public static T? GetService<T>()
        {
            Services ??= RegisterServices();
            ServiceProvider ??= Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            Services = services;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          /*  services.AddScoped<IService, Util.HttpClientService.Service>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            Services.AddScoped<IJsonWebToken, JsonWebToken>();
            services.AddTransient<IAwsS3, AwsS3>();
            services.AddTransient<IAPICalling, APICalling>();*/

            //add services

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            
         /*   services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IMasterInventoryService, MasterInventoryService>();
            services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            services.AddScoped<IFeaturePermissions, FeaturePermissions>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IMasterOrderService, MasterOrderService>();
            services.AddScoped<IFormDocumentService, FormDocumentService>();
            services.AddScoped<IMasterFacilityService, MasterFacilityService>();
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserProductService, UserProductService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterestedUserService, InterestedUserService>();
            services.AddScoped<IFacilityService, FacilityService>();*/
            return Services;
        }
    }
}

