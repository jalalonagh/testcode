
using Common;
using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebFramework.Configuration
{
    public static class AddElmahServiceExtensions
    {
        public static void AddElmah(this IServiceCollection services, IConfiguration configuration, SiteSettings siteSetting)
        {
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.Path = siteSetting.ElmahPath;
                options.LogPath = "~/Elmahlogs";
            });
        }
    }
}
