using Common;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using WebFramework.Configuration;
using WebFramework.MiddleWares;
using WebFramework.Permission;
using WebFramework.Session;
using WebFramework.Swagger;

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
            services.AddSingleton(new ResourceManager("MyApi.Properties.Resources", typeof(Startup).GetTypeInfo().Assembly));
            services.AddLocalization(options => options.ResourcesPath = "Properties");

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
            // تبدیل تاریخ و ساعت اپ به زمان رسمی
            var cultureInfo = new CultureInfo("fa-IR");
            cultureInfo.NumberFormat.CurrencySymbol = "R";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseMultiLanguage();

            app.IntializeDatabase();

            app.UseCustomExceptionHandler();

            app.UseStaticFiles(new StaticFileOptions
            {
            });

            app.UseElmah();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseSwaggerAndUI();

            app.UseSessionService();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints((endpoints) =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}