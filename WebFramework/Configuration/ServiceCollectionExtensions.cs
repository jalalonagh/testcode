
using Common;
using Common.Utilities;
using Data;
using Data.User;
using ElmahCore;
using ElmahCore.Mvc;
using Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebFramework.Permission;

namespace WebFramework.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddElmah(this IServiceCollection services, IConfiguration configuration, SiteSettings siteSetting)
        {
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.Path = siteSetting.ElmahPath;
                options.LogPath = "~/Elmahlogs";
            });
        }
        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                ApiVersion.TryParse("1.0", out var version10);
                ApiVersion.TryParse("1", out var version1);
                var a = version10 == version1;
            });
        }
    }
}
