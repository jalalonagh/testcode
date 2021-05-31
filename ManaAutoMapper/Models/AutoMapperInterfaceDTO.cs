using AutoMapper;
using Entities;
using ManaAutoMapper.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public abstract class AutoMapperInterfaceDTO<TDto, TEntity, TKey> : IHaveCustomMapping
        where TDto : class, new()
        where TEntity : IEntity, new()
        where TKey : struct
    {
        public TKey Id { get; set; }

        public TEntity ToEntity()
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TEntity>(CastToDerivedClass(this));
        }

        public string ToJson(TEntity entity)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        }

        public string ToJson(TDto model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        public TEntity ToEntity(TEntity entity)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map(CastToDerivedClass(this), entity);
        }

        public static TDto FromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDto>(model);
        }

        public static TDto FromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TDto>(json);
        }

        protected TDto CastToDerivedClass(AutoMapperInterfaceDTO<TDto, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDto>(baseInstance);
        }

        public void CreateMappings(AutoMapper.Profile profile)
        {
            var mappingExpression = profile.CreateMap<TDto, TEntity>();
            var mappingExpressionReverse = profile.CreateMap<TEntity, TDto>();

            var dtoType = typeof(TDto);
            var entityType = typeof(TEntity);

            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CustomMappings(mappingExpressionReverse);
            CustomMappingsReverse(mappingExpression);
        }

        public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
        {
        }

        public virtual void CustomMappingsReverse(IMappingExpression<TDto, TEntity> mapping)
        {
        }
    }
}
