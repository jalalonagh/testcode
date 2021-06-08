using System;

namespace ManaAutoMapper.Models
{
    public class JsonDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : class, new()
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public JsonDTO()
        {

        }

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
