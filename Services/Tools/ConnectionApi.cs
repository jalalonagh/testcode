using Common.Utilities;
using ManaSpeedTester;
using Microsoft.AspNetCore.Hosting;
using Services.Models;

namespace Services.Tools
{
    public class ConnectionApi
    {
        private readonly IHostingEnvironment _env;
        private TimeDurationTrackerSingleton tester;

        public ConnectionApi(IHostingEnvironment env)
        {
            _env = env;
            tester = TimeDurationTrackerSingleton.Instance;
        }

        public void saveToken(AccessToken model)
        {
            model.access_token = model.access_token.Replace("Bearer ", "");
            System.IO.File.WriteAllText(_env.ContentRootPath + "/Tokens/Token.txt", model.ToJson());
        }

        public AccessToken openToken()
        {
            if (System.IO.File.Exists(_env.ContentRootPath + "/Tokens/Token.txt"))
            {
                var json = System.IO.File.ReadAllText(_env.ContentRootPath + "/Tokens/Token.txt");

                return json.FromJson<AccessToken>();
            }

            return null;
        }
    }
}
