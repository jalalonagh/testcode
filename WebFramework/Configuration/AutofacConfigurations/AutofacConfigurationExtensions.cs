using Autofac;
using Autofac.Extensions.DependencyInjection;
using BaseBusiness;
using BusinessBaseConfig;
using Common;
using Entities;
using ManaBaseData;
using ManaBaseData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.DataInitializer;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebFramework.Api;

namespace WebFramework.Configuration.AutofacConfigurations
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            var list = new List<Assembly>() { typeof(ApiResult).Assembly, typeof(SiteSettings).Assembly, typeof(ISMSEntities).Assembly, typeof(ApplicationDbContext).Assembly,
                typeof(IDataInitializer).Assembly, typeof(IBL).Assembly, typeof(AccessToken).Assembly, typeof(Crud<,>).Assembly };
            containerBuilder.RegisterAssemblyTypes(list.ToArray())
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(list.ToArray())
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
            containerBuilder.RegisterAssemblyTypes(list.ToArray())
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