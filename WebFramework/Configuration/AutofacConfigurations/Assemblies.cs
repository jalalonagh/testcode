using BaseBusiness;
using BusinessBaseConfig;
using System.Reflection;

namespace WebFramework.Configuration.AutofacConfigurations
{
    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(IBL).Assembly;
        public static readonly Assembly[] Applications = new Assembly[] { typeof(IBL).Assembly, typeof(Crud<,,,>).Assembly };
    }
}
