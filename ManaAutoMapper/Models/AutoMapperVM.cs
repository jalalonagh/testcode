using Entities;
using System;

namespace ManaAutoMapper.Models
{
    [Serializable]
    public class AutoMapperVM<TVM, TEntity, TKey> : AutoMapperBaseVM<TVM, TEntity, TKey>
        where TVM : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
        public AutoMapperVM()
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

        public static TVM FromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;
            return mapper.GetMapper().Map<TVM>(model);
        }

        public TVM DTOFromEntity(TEntity model)
        {
            var mapper = LazySingleton.Instance;
            return mapper.GetMapper().Map<TVM>(model);
        }

        protected TVM CastToDerivedClass(AutoMapperVM<TVM, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TVM>(baseInstance);
        }
    }
}
