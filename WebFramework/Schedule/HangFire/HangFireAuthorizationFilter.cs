using Hangfire.Dashboard;
namespace WebFramework.Schedule.HangFire
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
            //var httpContext = context.GetHttpContext();
            //// Allow all authenticated users to see the Dashboard (potentially dangerous).
            //return httpContext.User.Identity.IsAuthenticated;
        }
    }
}
