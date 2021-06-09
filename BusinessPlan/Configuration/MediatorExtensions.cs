using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace BusinessLayout.Configuration
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(BusinessLayout.BaseBusiness.Query.GetAllAsync.GetAllAsyncQuery<,,,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }

                //foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>)))
                //{
                //    services.AddTransient(handlerType.AsType(), type.AsType());
                //}
            }

            return services;
        }
    }
}
