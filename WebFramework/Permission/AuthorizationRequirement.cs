using Common.Utilities;
using Entities.User.DapperPermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ServiceStack.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebFramework.Permission
{
    public class ChairModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object? Roles { get; set; }
        public object? ChairToUsers { get; set; }
    }

    public class AuthorizationRequirement : IAuthorizationRequirement { }

    public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        IHttpContextAccessor _httpContextAccessor = null;
        public PermissionHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            if (context.Resource is DefaultHttpContext resource)
            {
                if (resource.Request.HttpContext.Request.Host.Value.ToLower().Contains("localhost"))
                {
                    context.Succeed(requirement);
                    return;
                }
                var endpoint = resource.GetEndpoint() as RouteEndpoint;
                endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);
                endpoint.RoutePattern.RequiredValues.TryGetValue("action", out var _action);
                endpoint.RoutePattern.RequiredValues.TryGetValue("page", out var _page);
                endpoint.RoutePattern.RequiredValues.TryGetValue("area", out var _area);
                var isAuthenticated = context.User.Identity.IsAuthenticated;
                HttpContext httpContext = _httpContextAccessor.HttpContext; // Access context here
                var access = context.User.Claims.Where(x => x.Type == ClaimTypes.Authentication).ToList();
                var chairs = new List<ChairModel>();
                foreach (var item in access.Select(x => x.Value))
                {
                    var la = Newtonsoft.Json.JsonConvert.DeserializeObject<ChairModel[]>(item);
                    chairs.AddRange(la);
                }
                using (var connection = new RedisClient())
                {
                    var permisions = new List<DapperPermission>();
                    var bytes = connection.Get("PERMISSION");
                    if (bytes != null && bytes.Any())
                    {
                        var json = ASCIIEncoding.UTF8.GetString(bytes);
                        permisions = json.FromJson<List<DapperPermission>>();
                        var permited = permisions.Where(x => x.NavigationMenusControllerName == _controller.ToString() &&
                          x.NavigationMenusActionName == _action.ToString() && x.Permitted && chairs.Select(x => x.Id).Contains(x.ChairsId)
                          && x.NavigationMenusDomain.ToLower() == resource.Request.HttpContext.Request.Host.Value.ToLower()
                         ).Any();
                        if (isAuthenticated && permited && _controller != null && _action != null)
                        {
                            context.Succeed(requirement);
                            return;
                        }
                    }
                }
            }
            else
                context.Succeed(requirement);
        }
    }
}
