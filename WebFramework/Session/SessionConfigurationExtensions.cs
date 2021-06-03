using Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebFramework.Session
{
    public static class SessionConfigurationExtensions
    {
        public static void AddSessionService(this IServiceCollection services)
        {
            services.AddSession();
        }
        public static void UseSessionService(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));
            app.UseSession();
        }
    }
}
