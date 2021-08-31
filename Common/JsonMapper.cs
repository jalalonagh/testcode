using Newtonsoft.Json;

namespace Common
{
    public static class JsonMapper
    {
        public static T MapTo<T>(this object obj)
        {
            Newtonsoft.Json.Formatting fmt = Newtonsoft.Json.Formatting.None;
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, fmt, settings);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
