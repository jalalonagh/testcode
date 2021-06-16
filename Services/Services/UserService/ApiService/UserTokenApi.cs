using Common;
using Entities.User;
using ManaResourceManager;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Services.Models;
using Services.Tools;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.UserService.ApiService
{
    public class UserTokenApi : IUserTokenApi, IScopedDependency
    {
        private readonly IHttpClientFactory client;
        private readonly ResourceManagerSingleton resource;
        private readonly IHostingEnvironment env;

        public UserTokenApi(IHttpClientFactory _client, IHostingEnvironment _env)
        {
            client = _client;
            resource = ResourceManagerSingleton.GetInstance();
            env = _env;
        }
        public async Task<ServiceResult<Entities.User.User>> GetUserFormServer(string username, string url)
        {
            var http = client.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url + $"/{username}");
            var response = await http.SendAsync(request);
            var api = JsonConvert.DeserializeObject<ServiceResult<Entities.User.User>>(await response.Content.ReadAsStringAsync());
            return api;
        }
        public async Task<ServiceResult<JWTAuthModel>> GetToken(string username, string password, string url)
        {
            var http = client.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var formVariables = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };
            var content = new FormUrlEncodedContent(formVariables);
            request.Content = content;
            var response = await http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var api = JsonConvert.DeserializeObject<ServiceResult<JWTAuthModel>>(json ?? "");
            return api;
        }
        public async Task<ServiceResult<User>> CreateUserIntoServer(User user, string url)
        {
            user.Email = $"{user.UserName}@dinawin.com";
            var http = client.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    user = JsonConvert.DeserializeObject<User>(json);
                    return user;
                }
                return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorincreateuserfromjson").GetMessage());
            }
            return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.SERVER_ERROR, null, resource.FetchResource("errorincreateusertoserver").GetMessage());
        }
        public async Task<ServiceResult<User>> ResetPasswordIntoServer(User user, string url)
        {
            url = url + "/ResetPassword";
            var http = client.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url + $"?userName={user.UserName}");
            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                    return JsonConvert.DeserializeObject<User>(json);
                return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.LOGIC_ERROR, null, resource.FetchResource("errorinconvertjsontouser").GetMessage());
            }
            return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.LOGIC_ERROR, null, resource.FetchResource("errorinresetpassword").GetMessage());
        }
        public async Task<ServiceResult<Entities.User.User>> ChangeThePassword(string userName, string currentPassword, string newPassword, string url)
        {
            url = url + "/ChangeThePassword";
            var http = client.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url + $"?userName={userName}&currentPassword={currentPassword}&newPassword={newPassword}");
            var jWToken = new ConnectionApi(env).openToken().access_token;
            if (!string.IsNullOrEmpty(jWToken))
                request.Headers.Add("Authorization", "Bearer " + jWToken.Replace("\"", ""));
            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                    return JsonConvert.DeserializeObject<User>(json);
                return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.LOGIC_ERROR, null, resource.FetchResource("errorinconvertjsontouser").GetMessage());
            }
            return new ServiceResult<User>(false, ManaEnums.Api.ApiResultStatus.LOGIC_ERROR, null, resource.FetchResource("errorinchangepassword").GetMessage());
        }
    }
}
