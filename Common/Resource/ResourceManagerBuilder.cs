using System.Reflection;
using System.Resources;

namespace Common.Resource
{
    public class ResourceManagerBuilder
    {
        public ResourceManager Build()
        {
            var resource = new ResourceManager("MyApi.Resources.resources", Assembly.GetExecutingAssembly());
            return resource;
        }
    }
}