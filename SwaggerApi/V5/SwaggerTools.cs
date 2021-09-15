using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace SwaggerApi.V5
{
    public class SwaggerTools
    {
        public OpenApiSecurityScheme GenerateOpenApiSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute),
                    }
                }
            };
        }

        public bool ProccessDocInclusionPredicate(string docName, ApiDescription apiDesc)
        {
            if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
            var versions = methodInfo.DeclaringType.GetCustomAttributes<ApiVersionAttribute>(true).SelectMany(attr => attr.Versions);
            return versions.Any(v => $"v{v.ToString()}" == docName);
        }
    }
}
