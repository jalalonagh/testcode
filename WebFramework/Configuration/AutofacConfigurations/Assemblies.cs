using BaseBusiness;
using System.Reflection;

namespace WebFramework.Configuration.AutofacConfigurations
{
    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(Crud<,>).Assembly;
        public static readonly Assembly[] Applications = new Assembly[] { typeof(Crud<,>).Assembly };
    }
}
