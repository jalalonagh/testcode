using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessBaseConfig;
using Common;
using Entities;
using ManaBaseData;
using ManaBaseData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.DataInitializer;
using System;
using WebFramework.Api;
using WebFramework.Processing;

namespace WebFramework.Configuration.AutofacConfigurations
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            var commonAssembly = typeof(SiteSettings).Assembly;
            var entitiesAssembly = typeof(ISMSEntities).Assembly;
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
            services.AddSingleton(typeof(IApiResult), typeof(ApiResult));
            services.AddSingleton(typeof(IApiResult<>), typeof(ApiResult<>));
            services.AddSingleton(typeof(IResponseWriteTools), typeof(ResponseWriteTools));
            containerBuilder.Populate(services);
            containerBuilder.AddServices();
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new DataAccessModule(configuration.GetConnectionString("SqlServer")));
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}