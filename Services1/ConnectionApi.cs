using Common.Utilities;
using Microsoft.Extensions.Hosting;

namespace Services
{
    public class ConnectionApi
    {
        private readonly IHostingEnvironment _env;

        public ConnectionApi(IHostingEnvironment env)
        {
            _env = env;
        }
        public void saveToken(AccessTokenDto model)
        {
            model.access_token = model.access_token.Replace("Bearer ", "");
            System.IO.File.WriteAllText(_env.ContentRootPath + "/Tokens/Token.txt", model.ToJson());
        }
        public AccessTokenDto openToken()
        {
            if (System.IO.File.Exists(_env.ContentRootPath + "/Tokens/Token.txt"))
            {
                var json = System.IO.File.ReadAllText(_env.ContentRootPath + "/Tokens/Token.txt");
                return json.FromJson<AccessTokenDto>();
            }
            return null;

        }
    }
}
