using AutoMapper;
using Entities;
using ManaAutoMapper.Interfaces;
using System;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public abstract class AutoMapperNoIdDTO<TDto, TEntity, TKey> : AutoMapperBaseDTO<TDto, TEntity, TKey>
           where TDto : class, new()
           where TEntity : class, IEntity, new()
        where TKey : struct
    {
        public TEntity ToEntity()
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TEntity>(CastToDerivedClass(this));
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

        protected TDto CastToDerivedClass(AutoMapperNoIdDTO<TDto, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDto>(baseInstance);
        }
    }
}
