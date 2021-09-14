using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WebFramework.Configuration.JWTConfigurations;

namespace WebFramework.AbstractFactory.Services
{
    class ConcreteJWTServiceFactory : AbstractServiceFactory
    {
        [Obsolete]
        public override StartupServiceFactory AddService()
        {
            throw new NotImplementedException();
        }
        [Obsolete]
        public override StartupServiceFactory AddService(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public override StartupServiceFactory AddService(IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(jwtSettings.Encryptkey);
                var validationParameters = jwtSettings.GenerateValidationParameters(secretkey, encryptionkey);
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = jwtSettings.GenerateJWTBearerEvent();
            });
            return null;
        }
        [Obsolete]
        public override StartupServiceFactory AddService(IServiceCollection services, IConfiguration config)
        {
            throw new NotImplementedException();
        }
    }
}
