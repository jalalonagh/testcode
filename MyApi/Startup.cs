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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("SqlServer"));
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient);
            services.AddIdentity<User, Role>(identityOptions =>
            {
                identityOptions.Password.RequireDigit = _siteSetting.IdentitySettings.PasswordRequireDigit;
                identityOptions.Password.RequiredLength = _siteSetting.IdentitySettings.PasswordRequiredLength;
                identityOptions.Password.RequireNonAlphanumeric = _siteSetting.IdentitySettings.PasswordRequireNonAlphanumic;
                identityOptions.Password.RequireUppercase = _siteSetting.IdentitySettings.PasswordRequireUppercase;
                identityOptions.Password.RequireLowercase = _siteSetting.IdentitySettings.PasswordRequireLowercase;
                identityOptions.User.RequireUniqueEmail = _siteSetting.IdentitySettings.RequireUniqueEmail;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            })
                            .AddApiExplorer()
                            .AddAuthorization(options =>
                            {
                                //options.AddPolicy("Authorization", policyCorrectUser =>
                                //{
                                //    policyCorrectUser.Requirements.Add(new AuthorizationRequirement());
                                //});
                            })
                            .AddFormatterMappings()
                            .AddDataAnnotations()
                            .AddNewtonsoftJson(option =>
                            {
                                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                                option.SerializerSettings.MaxDepth = 7;
                                option.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
                            })
                        .SetCompatibilityVersion(CompatibilityVersion.Latest);
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
            }); services.AddCustomApiVersioning();
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