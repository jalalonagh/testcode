using AutoMapper;
using Entities;
using ManaAutoMapper.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public abstract class AutoMapperDTO<TDto, TEntity, TKey> : AutoMapperBaseDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
        public TKey Id { get; set; }

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

        protected TDto CastToDerivedClass(AutoMapperDTO<TDto, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDto>(baseInstance);
        }
    }
}
