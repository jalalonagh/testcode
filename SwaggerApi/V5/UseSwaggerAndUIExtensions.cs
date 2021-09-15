using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SwaggerApi.V5
{
    public static class UseSwaggerAndUIExtensions
    {
        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger(options => { });
            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });
        }
    }
}
