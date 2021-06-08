using AutoMapper;
using Entities;
using ManaAutoMapper.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public class AutoMapperInterfaceVM<TVM, TEntity, TKey> : AutoMapperBaseVM<TVM, TEntity, TKey>
        where TVM : class, new()
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

        public static TVM FromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TVM>(model);
        }
    }
}
