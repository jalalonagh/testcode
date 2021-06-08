using System;

namespace ManaAutoMapper.Models
{
    public class JsonVM<TVM, TEntity, TKey>
        where TVM : class, new()
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

        public JsonVM()
        {

        }

        public string ToJson(TEntity entity)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        }

        public string ToJson(TVM model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        public static TVM DTOFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TVM>(json);
        }

        public static TEntity EntityFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
