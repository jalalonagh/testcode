using Common.Utilities;
using ManaSpeedTester;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
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

        public void saveToken(AccessTokenDTO model)
        {
            model.access_token = model.access_token.Replace("Bearer ", "");
            System.IO.File.WriteAllText(_env.ContentRootPath + "/Tokens/Token.txt", model.ToJson());
        }

        public AccessTokenDTO openToken()
        {
            if (System.IO.File.Exists(_env.ContentRootPath + "/Tokens/Token.txt"))
            {
                var json = System.IO.File.ReadAllText(_env.ContentRootPath + "/Tokens/Token.txt");

                return json.FromJson<AccessTokenDTO>();
            }

            return null;
        }
    }
}
