using Entities;
using System;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public class AutoMapperDTO<TDto, TEntity, TKey> : AutoMapperBaseDTO<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : BaseEntity
        where TKey : struct
    {
        public AutoMapperDTO()
        {

        }

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
