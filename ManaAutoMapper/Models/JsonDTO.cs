using Entities;
using Entities.Common;

namespace ManaAutoMapper.Models
{
    public abstract class JsonDTO<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class, new()
    {
        public string ToJson(TEntity entity)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        }

        public string ToJson(TDto model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        public static TDto DTOFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDto>(json);
        }

        public static TEntity EntityFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
