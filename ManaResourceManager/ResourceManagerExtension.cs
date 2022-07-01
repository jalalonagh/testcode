using ManaResourceManager;
using ManaResourceManager.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanternetResourceManager
{
    public static class ResourceManagerExtension
    {
        public static void AddResourceManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ResourceManagerSettings>(configuration.GetSection(nameof(ResourceManagerSettings)));
            services.AddSingleton<IResourceService, ResourceService>();
        }
    }
}
