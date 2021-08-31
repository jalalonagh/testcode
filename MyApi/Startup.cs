using Common;
using ElmahCore.Mvc;
using ManaDataTransferObjectValidator;
using ManaEntitiesValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwaggerApi.V5;
using System;
using System.Globalization;
using WebFramework.Configuration;
using WebFramework.Configuration.AutofacConfigurations;
using WebFramework.Extensions;
using WebFramework.MiddleWares;
using WebFramework.Permission;
using WebFramework.Session;

namespace MyApi
{
    public class Startup
    {
        private readonly SiteSettings _siteSetting;
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddHttpClient();
            services.AddSession();
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.AddDbContext(Configuration);
            services.AddCustomIdentity(_siteSetting.IdentitySettings);
            services.AddMinimalMvc();
            services.AddControllersWithViews();
            services.AddElmah(Configuration, _siteSetting);
            services.AddJwtAuthentication(_siteSetting.JwtSettings);
            services.AddCustomApiVersioning();
            services.AddSwagger();
            services.AddSessionService();
            services.AddDTOValidationService(Configuration);
            services.AddEntitiesValidationService(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            return services.BuildAutofacServiceProvider(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("fa-IR");
            cultureInfo.NumberFormat.CurrencySymbol = "R";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            app.UseMultiLanguage();
            app.IntializeDatabase();
            app.UseCustomExceptionHandler();
            app.UseStaticFiles(new StaticFileOptions { });
            app.UseElmah();
            app.UseHttpsRedirection();
            app.UseSwaggerAndUI();
            app.UseSessionService();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints((endpoints) =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}