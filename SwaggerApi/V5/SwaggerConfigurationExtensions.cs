using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;

namespace SwaggerApi.V5
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblies();
            services.AddSwaggerGen(options =>
            {
                var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "MyApi.xml");
                options.IncludeXmlComments(xmlDocPath, true);
                options.CustomSchemaIds(x => x.FullName);
                options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2" });
                options.ExampleFilters();
                options.OperationFilter<ApplySummariesOperationFilter>();
                options.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "Bearer");
                options.AddSecurityDefinition("Bearer", new SwaggerTools().GenerateOpenApiSecurityScheme());
                options.OperationFilter<RemoveVersionParameters>();
                options.DocumentFilter<SetVersionInPaths>();
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    return new SwaggerTools().ProccessDocInclusionPredicate(docName, apiDesc);
                });
            });
        }
    }
}
