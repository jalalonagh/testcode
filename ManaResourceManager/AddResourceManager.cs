using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanternetResourceManager
{
    public static class ResourceManagerExtension
    {
        public static AddResourceManager(this IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

        }
    }
}
