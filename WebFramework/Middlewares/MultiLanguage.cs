using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebFramework.MiddleWares
{
    public static class MultiLanguage
    {
        public static void UseMultiLanguage(this IApplicationBuilder app)
        {
            // Localization: Here we are building a list of supported cultures which will be used in the
            //               RequestLocalizationOptions in the app.UseRequestLocalization call below.
            var supportedCultures = new[]
              {
                    // Localization: Notice that neutral cultures (like 'es') are
                    //               listed after specific cultures. This best practice
                    //               ensures that if a particular culture request could
                    //               be satisifed by either a supported specific culture
                    //               or a supported neutral culture, the specific culture
                    //               will be preferred.
                    //new CultureInfo("en-US"),
                    //new CultureInfo("fr-FR"),
                    new CultureInfo("fa-IR"),
                    //new CultureInfo("es"),
              };


            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),

                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,

                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            };

            // Localization: If needed, it's straight-forward to add custom request culture providers which can
            //               extract requested culture from an HTTP context using arbitrary business logic.
            requestLocalizationOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async httpContext =>
            {
                return new ProviderCultureResult("fa-IR");
            }));



            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    ApplyCurrentCultureToResponseHeaders = true
            //});


            app.UseRequestLocalization(requestLocalizationOptions);
        }
    }
}