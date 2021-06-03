using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebFramework.MiddleWares
{
    public static class MultiLanguage
    {
        public static void UseMultiLanguage(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
              {
                    new CultureInfo("fa-IR"),
              };
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            requestLocalizationOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async httpContext =>
            {
                return new ProviderCultureResult("fa-IR");
            }));
            app.UseRequestLocalization(requestLocalizationOptions);
        }
    }
}