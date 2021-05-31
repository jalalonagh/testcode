using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using MyApi.Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Controllers.Api.v1
{

    public class NavigationMenu
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentMenuId { get; set; }

        public virtual NavigationMenu ParentNavigationMenu { get; set; }

        public string Area { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool IsExternal { get; set; }

        public string ExternalUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool Permitted { get; set; }

        public bool Visible { get; set; }
        public string Domain { get; set; }
    }

    public class MvcActionInfo
    {
        public string Id => $"{ControllerId}:{Name}";

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ControllerId { get; set; }
    }
    public class MvcControllerInfo
    {
        public string Id => $"{AreaName}:{Name}";

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string AreaName { get; set; }

        public IEnumerable<MvcActionInfo> Actions { get; set; }
    }


    [ApiVersion("1")]
    public class AccessController : BaseController
    {
        private IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly IHttpClientFactory _clientFactory;
        [Obsolete]
        private readonly IHostingEnvironment _env;
        private readonly SiteSettings siteSettings;

        [Obsolete]
        public AccessController(IHttpClientFactory clientFactory,
            IConfiguration configuration,
           [FromServices] IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
                    IHostingEnvironment env)
        {
            _clientFactory = clientFactory;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _env = env;
            siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        [Obsolete]
        private async Task Autorization()
        {
            var token = await Token(new TokenRequest
            {
                password = siteSettings.Password,
                username = siteSettings.UserName,
                grant_type = "password"
            }, CancellationToken.None);

            new ConnectionApi(_env).saveToken(new AccessTokenDTO
            {
                access_token = token.Data.jwt.access_token
            });
        }

        [Obsolete]
        private async Task<ServiceResult<TokenDTO>> Token(TokenRequest tokenRequest, CancellationToken cancellationToken)
        {

            string url = siteSettings.UriUserInfo + "/TokenWithModel";
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var formVariables = new List<KeyValuePair<string, string>>();
            formVariables.Add(new KeyValuePair<string, string>("grant_type", "password"));
            formVariables.Add(new KeyValuePair<string, string>("username", tokenRequest.username));
            formVariables.Add(new KeyValuePair<string, string>("password", tokenRequest.password));

            FormUrlEncodedContent content = new FormUrlEncodedContent(formVariables);
            request.Content = content;

            var response = await client.SendAsync(request);

            var api = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult<TokenDTO>>(await response.Content.ReadAsStringAsync());

            if (api.IsSuccess)
            {
                new ConnectionApi(_env).saveToken(api.Data.jwt);
            }

            return api;
        }

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

        [Obsolete]
        async Task sendToTokenService()
        {
        again:
            string url = siteSettings.UriUserInfo;
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);


            var JWToken = new ConnectionApi(_env).openToken()?.access_token;
            if (!string.IsNullOrEmpty(JWToken))
            {
                request.Headers.Add("Authorization", "Bearer " + JWToken.Replace("\"", ""));
            }

            var response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await Autorization();
                goto again;
            }

            var api = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceResult>(await response.Content.ReadAsStringAsync());
        }

    }
}
