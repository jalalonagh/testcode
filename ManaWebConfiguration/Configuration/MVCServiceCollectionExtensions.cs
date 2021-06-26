using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using WebFramework.Permission;

namespace WebFramework.Configuration
{
    public static class MVCServiceCollectionExtensions
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void UseMinimalMvc(this IApplicationBuilder app)
        {
            app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        }
        public static void AddMinimalMvc(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
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
            .AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
