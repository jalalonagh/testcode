using Autofac;
using Autofac.Core.Activators.Reflection;
using Autofac.Extensions.DependencyInjection;
using BusinessBaseConfig;
using Common;
using Data;
using Data.Repositories;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileBusiness;
using Services.DataInitializer;
using SMSBusiness;
using SMSConfirmationBusiness;
using SMSRegexBusiness;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using TransactionBusiness;
using UserBusiness;

namespace WebFramework.Configuration
{
    internal class AllConstructorFinder : IConstructorFinder
    {
        private static readonly ConcurrentDictionary<Type, ConstructorInfo[]> Cache = new ConcurrentDictionary<Type, ConstructorInfo[]>();
        public ConstructorInfo[] FindConstructors(Type targetType)
        {
            var result = Cache.GetOrAdd(targetType, t => t.GetTypeInfo().DeclaredConstructors.ToArray());
            return result.Length > 0 ? result : throw new NoConstructorsFoundException(targetType);
        }
    }

    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IBL).Assembly;
        public static readonly Assembly[] Applications = new Assembly[] { typeof(IBL).Assembly, typeof(IPrB).Assembly,
            typeof(ISmB).Assembly, typeof(ISCB).Assembly, typeof(ISRB).Assembly, typeof(ITrB).Assembly, typeof(IUsB).Assembly};
    }

    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            var commonAssembly = typeof(SiteSettings).Assembly;
            var entitiesAssembly = typeof(IEntity).Assembly;
            var dataAssembly = typeof(ApplicationDbContext).Assembly;
            var servicesAssembly = typeof(IDataInitializer).Assembly;
            var BLAssembly = typeof(IBL).Assembly;
            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly, BLAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly, BLAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly, BLAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.AddServices();
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new DataAccessModule(configuration.GetConnectionString("SqlServer")));
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}