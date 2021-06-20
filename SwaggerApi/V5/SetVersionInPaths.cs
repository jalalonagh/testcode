using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace SwaggerApi.V5
{
    public class SetVersionInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var updatePaths = new OpenApiPaths();
            foreach (var entry in swaggerDoc.Paths.ToList())
                updatePaths.Add(entry.Key.Replace("v{version}", swaggerDoc.Info.Version), entry.Value);
            swaggerDoc.Paths = updatePaths;
        }
    }
}
