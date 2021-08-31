using Newtonsoft.Json.Serialization;
using System.Linq;

namespace WebFramework.Resolvers
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var t = propertyName.ToCharArray().ToList();
            return t[0].ToString().ToLowerInvariant() + string.Join(string.Empty, t.Skip(1));
        }
    }
}
