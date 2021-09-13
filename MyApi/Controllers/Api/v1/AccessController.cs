using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyApi.Models.Access;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{
    [ApiVersion("1")]
    public class AccessController : BaseController
    {
        private IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IHttpClientFactory _clientFactory;
        private readonly SiteSettings siteSettings;

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task GetControllers()
        {
            var _mvcControllers = new List<MvcControllerInfo>();
            var items = _actionDescriptorCollectionProvider
                .ActionDescriptors.Items
                .OfType<ControllerActionDescriptor>()
                .Select(descriptor => descriptor)
                .GroupBy(descriptor => descriptor.ControllerTypeInfo.FullName)
                .ToList();
            foreach (var actionDescriptors in items)
            {
                if (!actionDescriptors.Any())
                    continue;
                var actionDescriptor = actionDescriptors.First();
                var controllerTypeInfo = actionDescriptor.ControllerTypeInfo;
                var currentController = new MvcControllerInfo
                {
                    AreaName = controllerTypeInfo.GetCustomAttribute<AreaAttribute>()?.RouteValue,
                    DisplayName = controllerTypeInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName,
                    Name = actionDescriptor.ControllerName,
                };
                var actions = new List<MvcActionInfo>();
                foreach (var descriptor in actionDescriptors.GroupBy(a => a.ActionName).Select(g => g.First()))
                {
                    var methodInfo = descriptor.MethodInfo;
                    if (IsProtectedAction(controllerTypeInfo, methodInfo))
                        actions.Add(new MvcActionInfo
                        {
                            ControllerId = currentController.Id,
                            Name = descriptor.ActionName,
                            DisplayName = methodInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName,
                        });
                }
                if (actions.Any())
                {
                    currentController.Actions = actions;
                    _mvcControllers.Add(currentController);
                }
            }
            List<NavigationMenu> ls = new List<NavigationMenu>();
            foreach (var item in _mvcControllers)
            {
                ls.AddRange(item.Actions.Select(x => new NavigationMenu
                {
                    ActionName = x.Name,
                    Name = x.DisplayName,
                    Area = item.AreaName,
                    ControllerName = item.Name,
                    ParentNavigationMenu = new NavigationMenu
                    {
                        ControllerName = item.Name,
                        Name = item.DisplayName,
                        Area = item.AreaName
                    }
                }));
            }
            var lll = ls.ToList();
            lll.ForEach(x => x.Domain = HttpContext.Request.Host.Value);
            string url = siteSettings.UriTokenService;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url + $"/Access/SetController");
            StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(lll), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
        }

        private static bool IsProtectedAction(MemberInfo controllerTypeInfo, MemberInfo actionMethodInfo)
        {
            if (actionMethodInfo.GetCustomAttribute<AllowAnonymousAttribute>(true) != null)
                return false;
            if (controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>(true) != null)
                return true;
            if (actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>(true) != null)
                return true;
            return false;
        }
    }
}
