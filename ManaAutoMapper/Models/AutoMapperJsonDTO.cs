﻿using Entities;
using Entities.Common;

namespace ManaAutoMapper.Models
{
    public abstract class AutoMapperJsonDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {
        public TKey Id { get; set; }

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

        //public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
        //{
        //}

        //public virtual void CustomMappingsReverse(IMappingExpression<TDto, TEntity> mapping)
        //{
        //}
    }
}