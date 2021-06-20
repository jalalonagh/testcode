using BusinessBaseConfig;
using System.Reflection;

namespace SampleProject.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IBL).Assembly;
    }
}