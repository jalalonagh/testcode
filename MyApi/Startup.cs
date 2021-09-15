using Common;
using ElmahCore.Mvc;
using Entities.User;
using Entities.User.Role;
using ManaBaseData;
using ManaDataTransferObjectValidator;
using ManaEntitiesValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StartupConfiguration;
using SwaggerApi.V5;
using System;
using System.Globalization;
using System.Text;
using WebFramework.Configuration;
using WebFramework.Configuration.AutofacConfigurations;
using WebFramework.Configuration.JWTConfigurations;
using WebFramework.Extensions;
using WebFramework.MiddleWares;
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
            services.AddHttpClient();
            services.AddSession();
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            services.SetStartupAddDbContext<ApplicationDbContext, IConfiguration>(Configuration);
            services.AddIdentity<User, Role>(identityOptions =>
            {
                identityOptions = identityOptions.SetStartupAddIdentityOptions(_siteSetting.IdentitySettings.MapTo<StartupConfiguration.Models.IdentitySettings>());
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.SetStartupAddMVCCoreBase();
            services.AddControllersWithViews();
            services.AddElmah(Configuration, _siteSetting);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey);
                var validationParameters = _siteSetting.JwtSettings.GenerateValidationParameters(secretkey, encryptionkey);
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = _siteSetting.JwtSettings.GenerateJWTBearerEvent();
            });
            services.AddCustomApiVersioning();
            services.AddSwagger();
            services.AddSessionService();
            services.AddDTOValidationService(Configuration);
            services.AddEntitiesValidationService(Configuration);
            services.SetStartupAddCors(MyAllowSpecificOrigins);
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