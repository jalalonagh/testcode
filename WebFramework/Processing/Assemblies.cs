using BaseBusiness.Models;
using System.Collections.Generic;
using System.Reflection;

namespace SampleProject.Infrastructure.Processing
{
    public static class Assemblies
    {
        public static readonly IEnumerable<Assembly> Applications = new List<Assembly>() { typeof(BusinessResult).Assembly };
    }
}