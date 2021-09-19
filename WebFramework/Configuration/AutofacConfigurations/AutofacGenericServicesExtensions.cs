using Autofac;
using BaseBusiness;
using Common;
using Entities;
using ManaBaseData;
using ManaBaseData.Repositories;
using Services.DataInitializer;
using Services.Models;
using System.Collections.Generic;
using System.Reflection;
using WebFramework.Api;

namespace WebFramework.Configuration.AutofacConfigurations
{
    public static class AutofacGenericServicesExtensions
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
    }
}
