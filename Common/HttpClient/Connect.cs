using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpClient
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    public class Connect<TData>
    {
        protected string _url = "https://token.dinavision.org/";

        public Connect(string baseUrl)
        {
            _url = baseUrl;
        }

        public Connect()
        {

        }

        public async Task<TData> Get(string urlMethod, string ApiToken)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var result = client.GetAsync(_url + urlMethod).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    token = Authorization(ApiToken).Result;
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    result = client.GetAsync(_url + urlMethod).Result;
                }
                var ttt = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TData>(await result.Content.ReadAsStringAsync());
            }
        }

        protected string token;

        protected async Task<string> Authorization(string apiPath)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var comment = "hello world";
                var questionId = 1;

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type","password"),
                    new KeyValuePair<string, string>("username", "admin" ),
                    new KeyValuePair<string, string>("password","1234567")
                });

                var r = client.PostAsync(apiPath, formContent).Result;
                var content = r.Content.ReadAsStringAsync().Result;

                token = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessToken>(content).access_token;
                return token;
            }
        }
    }

    public class Connect<TData, TResult> : Connect<TData>
    {
        public async Task<TResult> Post(string urlMethod, TData data, string apiPathToken)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var json = JsonConvert.SerializeObject(data);
                var dataJson = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(urlMethod, dataJson);

                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    token = base.Authorization(apiPathToken).Result;
                    var dataJson2 = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    result = await client.PostAsync(urlMethod, dataJson2);
                }

                return JsonConvert.DeserializeObject<TResult>(await result.Content.ReadAsStringAsync());
            }
        }
    }
}