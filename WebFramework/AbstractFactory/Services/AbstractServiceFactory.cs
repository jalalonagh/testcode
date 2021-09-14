using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebFramework.AbstractFactory.Services
{
    abstract class AbstractServiceFactory
    {
        public abstract StartupServiceFactory AddService();
        public abstract StartupServiceFactory AddService(IServiceCollection services);
        public abstract StartupServiceFactory AddService(IServiceCollection services, JwtSettings settings);
        public abstract StartupServiceFactory AddService(IServiceCollection services, IConfiguration config);
    }
}
