using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using WebFramework.Permission;

namespace WebFramework.Configuration
{
    public static class MVCServiceCollectionExtensions
    {
        public static void AddMinimalMvc(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .AddApiExplorer()
                .AddAuthorization(options =>
                {
                    options.AddPolicy("Authorization", policyCorrectUser =>
                    {
                        policyCorrectUser.Requirements.Add(new AuthorizationRequirement());
                    });
                })
                .AddFormatterMappings()
                .AddDataAnnotations()
                .AddNewtonsoftJson(option =>
                 {
                     option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                     option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                     option.SerializerSettings.MaxDepth = 7;
                     option.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
                     option.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                 })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }
    }
}
