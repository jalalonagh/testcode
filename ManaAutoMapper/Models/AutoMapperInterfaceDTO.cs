using Entities.Common;
using System;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public class AutoMapperInterfaceDTO<TDto, TEntity, TKey> : AutoMapperBaseDTO<TDto, TEntity, TKey>
        where TDto : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {

        public TEntity ToEntity()
        {
            var mapper = LazySingletonDTO.SetCustomAssembly(typeof(TDto).Assembly);

            return mapper.GetMapper().Map<TEntity>(CastToDerivedClass(this));
        }

        public TEntity ToEntity(TEntity entity)
        {
            var mapper = LazySingletonDTO.SetCustomAssembly(typeof(TDto).Assembly);

            return mapper.GetMapper().Map(CastToDerivedClass(this), entity);
        }

        public static TDto FromEntity(TEntity model)
        {
            var mapper = LazySingletonDTO.SetCustomAssembly(typeof(TDto).Assembly);

            return mapper.GetMapper().Map<TDto>(model);
        }
    }
}
