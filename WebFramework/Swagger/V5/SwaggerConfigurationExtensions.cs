using Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebFramework.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            Assert.NotNull(services, nameof(services));

            //Add services to use Example Filters in swagger
            services.AddSwaggerExamplesFromAssemblies();
            //Add services and configuration to use swagger
            services.AddSwaggerGen(options =>
            {
                var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "MyApi.xml");
                //show controller XML comments like summary
                options.IncludeXmlComments(xmlDocPath, true);
                options.CustomSchemaIds(x => x.FullName);
                options.EnableAnnotations();
                options.DescribeAllEnumsAsStrings();
                //options.DescribeAllParametersInCamelCase();
                //options.DescribeStringEnumsInCamelCase()
                //options.UseReferencedDefinitionsForEnums()
                //options.IgnoreObsoleteActions();
                //options.IgnoreObsoleteProperties();

                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2" });

                #region Filters
                //Enable to use [SwaggerRequestExample] & [SwaggerResponseExample]
                options.ExampleFilters();

                //Adds an Upload button to endpoints which have [AddSwaggerFileUploadButton]
                //options.OperationFilter<AddFileParamTypesOperationFilter>();

                //Set summary of action if not already set
                options.OperationFilter<ApplySummariesOperationFilter>();

                #region Add UnAuthorized to Response
                //Add 401 response and security requirements (Lock icon) to actions that need authorization
                options.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "Bearer");
                #endregion

                #region Add Jwt Authentication
                //Add Lockout icon on top of swagger ui page to authenticate
                //options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header"
                //});
                //options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[] { }}
                //});
                //v5
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "tomsAuth"
                //});

                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "tomsAuth" }
                //        }, new List<string>() }
                //});

                //                options.AddSecurityDefinition("Bearer", new OAuth2Scheme
                //                {
                //                    Flow = "password",
                //#if DEBUG
                //                    TokenUrl = "https://localhost:44339/api/v1/users/Token",
                //#else
                //                    TokenUrl = "http://token.dinavision.org/api/v1/users/Token",
                //#endif
                //                });

                //                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //                {
                //                    Description =
                //             "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                //                    Name = "Authorization",
                //                    In = ParameterLocation.Header,
                //                    Type = SecuritySchemeType.OAuth2,
                //                    Scheme = "Bearer",



                //             Flows = new OpenApiOAuthFlows
                //             {

                //                 Password = new OpenApiOAuthFlow
                //                 {

                //#if DEBUG

                //                     TokenUrl = new Uri("http://localhost:56960/api/v1/users/Token")
                //#else
                //                                                TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute)
                //#endif

                //                     //TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute),
                //                     //,Scopes = new Dictionary<string, string>{
                //                     //    { "client_id:", "clientId" },
                //                     //    { "client_Secret", "clientSecret" }
                //                     //}

                //                 }
                //             }

                //                });

                //                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.RequestBody,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,



                //        },
                //        new List<string>()
                //    }
                //});


                //                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //                {
                //                    Type = SecuritySchemeType.OAuth2,
                //                    Scheme = "Bearer",
                //                    BearerFormat = "JWT",

                //                    Flows = new OpenApiOAuthFlows
                //                    {

                //                        Password = new OpenApiOAuthFlow
                //                        {

                //#if DEBUG

                //                            TokenUrl = new Uri("http://localhost:56960/api/v1/users/Token", UriKind.Absolute)
                //#else
                //                                                                TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute)
                //#endif

                //                            //TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute),
                //                            //,Scopes = new Dictionary<string, string>{
                //                            //    { "client_id:", "clientId" },
                //                            //    { "client_Secret", "clientSecret" }
                //                            //}

                //                        }
                //                    }
                //                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                  
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            //AuthorizationUrl = new Uri("http://localhost:56960/api/v1/users/Token", UriKind.Absolute),
#if DEBUG
                            TokenUrl = new Uri("http://localhost:56960/api/v1/users/Token", UriKind.Absolute),
#else
                            TokenUrl = new Uri("https://token.dinavision.org/api/v1/users/Token", UriKind.Absolute),

#endif
                            //Scopes = new Dictionary<string, string>
                            //{
                            //    { "readAccess", "Access read operations" },
                            //    { "writeAccess", "Access write operations" }
                            //}
                        }
                    }
                });
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {

                //        new OpenApiSecurityScheme
                //        {
                //            Type= SecuritySchemeType.OAuth2,
                //             Flows= new OpenApiOAuthFlows
                //             {
                //                  Password=new OpenApiOAuthFlow
                //                  {
                //                        TokenUrl = new Uri("http://localhost:56960/api/v1/users/Token", UriKind.Absolute),
                //                  }
                //             }
                //            //Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                //        }
                //        ,
                //        new[] { "readAccess", "writeAccess" }
                //    }
                //});


                //                options.AddSecurityDefinition("Bearer", new OAuth2Scheme
                //                {
                //                    Flow = "password",
                //#if DEBUG
                //                    TokenUrl = "https://localhost:44339/api/v1/users/Token",
                //#else
                //                                    TokenUrl = "http://token.dinavision.org/api/v1/users/Token",
                //#endif
                //                });


                //                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //                {
                //                    Type= SecuritySchemeType.OAuth2,
                //                     BearerFormat="JWT",
                //                    Flows = new OpenApiOAuthFlows()
                //                    {
                //                        Password = new OpenApiOAuthFlow
                //                        {
                //                            TokenUrl = new Uri("http://localhost:56960/api/v1/users/Token", UriKind.Absolute),
                //                        }
                //                    },
                ////#if DEBUG
                ////                    TokenUrl = "https://localhost:44339/api/v1/users/Token",
                ////#else
                ////                                    TokenUrl = "http://token.dinavision.org/api/v1/users/Token",
                ////#endif
                //                });

#endregion

#region Versioning
                // Remove version parameter from all Operations
                options.OperationFilter<RemoveVersionParameters>();

                //set version "api/v{version}/[controller]" from current swagger doc verion
                options.DocumentFilter<SetVersionInPaths>();

                //Seperate and categorize end-points by doc version
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
#endregion

                //If use FluentValidation then must be use this package to show validation in swagger (MicroElements.Swashbuckle.FluentValidation)
                //options.AddFluentValidationRules();
#endregion
            });
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));

            //Swagger middleware for generate "Open API Documentation" in swagger.json
            app.UseSwagger(options =>
            {
                //options.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });

            //Swagger middleware for generate UI from swagger.json
            app.UseSwaggerUI(options =>
            {
#region Customizing
                //// Display
                //options.DefaultModelExpandDepth(2);
                //options.DefaultModelRendering(ModelRendering.Model);
                //options.DefaultModelsExpandDepth(-1);
                //options.DisplayOperationId();
                //options.DisplayRequestDuration();
                options.DocExpansion(DocExpansion.None);
                //options.EnableDeepLinking();
                //options.EnableFilter();
                //options.MaxDisplayedTags(5);
                //options.ShowExtensions();

                //// Network
                //options.EnableValidator();
                //options.SupportedSubmitMethods(SubmitMethod.Get);

                //// Other
                //options.DocumentTitle = "CustomUIConfig";
                //options.InjectStylesheet("/ext/custom-stylesheet.css");
                //options.InjectJavascript("/ext/custom-javascript.js");
                //options.RoutePrefix = "api-docs";
#endregion
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });
        }
    }
}
