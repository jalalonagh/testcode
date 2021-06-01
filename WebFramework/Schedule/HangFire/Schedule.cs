using Common;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFramework.Schedule.HangFire;

namespace WebFramework.Schedule
{
    public static class Schedule
    {
        public static void AddHangFireService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Hangfire services.  
            services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("HangFire")));
        }

        public static void UseHangFire(this IApplicationBuilder app, HangFireSettings HangFireSettings)
        {
            // Add Path,Run Dashboard
            app.UseHangfireDashboard(HangFireSettings.HangFirePath, new DashboardOptions
            {
                Authorization = new[] { new HangFireAuthorizationFilter() },
                //   IsReadOnlyFunc = (DashboardContext context) => true
            });
            // Add Server
            app.UseHangfireServer();

            //BackgroundJob.Enqueue(() => Console.WriteLine("Getting Started with HangFire!"));

            //BackgroundJob.Schedule(() => Console.WriteLine("This background job would execute after a delay."), TimeSpan.FromMilliseconds(1000 * 15));

            //Add Job Calc
            //"*/59 * * * * *"
            //RecurringJob.AddOrUpdate(() =>
            //CalcCommission.CalcAll(), HangFireSettings.Duration
            //    );
        }
    }
}
