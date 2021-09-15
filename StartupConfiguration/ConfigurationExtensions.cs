using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StartupConfiguration.Models;
using System.Text;

namespace StartupConfiguration
{
    public static class ConfigurationExtensions
    {
        public static void SetStartupAddDbContext<DB, Conf>(this IServiceCollection services, Conf conf)
            where DB : DbContext
            where Conf : IConfiguration
        {
            services.AddDbContext<DB>(options =>
            {
                options.UseSqlServer(conf.GetConnectionString("SqlServer"));
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient);
        }

        public static IdentityOptions SetStartupAddIdentityOptions(this IdentityOptions options, IdentitySettings settings)
        {
            options.Password.RequireDigit = settings.PasswordRequireDigit;
            options.Password.RequiredLength = settings.PasswordRequiredLength;
            options.Password.RequireNonAlphanumeric = settings.PasswordRequireNonAlphanumic;
            options.Password.RequireUppercase = settings.PasswordRequireUppercase;
            options.Password.RequireLowercase = settings.PasswordRequireLowercase;
            options.User.RequireUniqueEmail = settings.RequireUniqueEmail;
            return options;
        }

        public static void SetStartupAddMVCCoreBase(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddApiExplorer()
            .AddFormatterMappings()
            .AddDataAnnotations()
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public static void SetStartupAddMVCCoreNewtonsoftJson(this IMvcCoreBuilder builder)
        {
            builder.AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                option.SerializerSettings.MaxDepth = 7;
                option.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
            });
        }

        public static void SetStartupAddAuthentication(this IServiceCollection services, JWTSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(settings.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(settings.Encryptkey);
                var validationParameters = settings.JwtSettings.GenerateValidationParameters(secretkey, encryptionkey);
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = _siteSetting.JwtSettings.GenerateJWTBearerEvent();
            });
        }
    }
}
