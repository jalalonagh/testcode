using AutoMapper;
using Entities.Common;
using ManaAutoMapper.Interfaces;

namespace ManaAutoMapper.Models
{
    public class AutoMapperBaseDTO<TDTO, TEntity, TKey> : JsonDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
        public AutoMapperBaseDTO()
        {

        }

        protected TDTO CastToDerivedClass(AutoMapperInterfaceDTO<TDTO, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingleton.Instance;

            return mapper.GetMapper().Map<TDTO>(baseInstance);
        }

        public void CreateMappings(AutoMapper.Profile profile)
        {
            var mappingExpression = profile.CreateMap<TDTO, TEntity>();
            var mappingExpressionReverse = profile.CreateMap<TEntity, TDTO>();

            var dtoType = typeof(TDTO);
            var entityType = typeof(TEntity);

            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CustomMappings(mappingExpressionReverse);
            CustomMappingsReverse(mappingExpression);
        }

        public virtual void CustomMappings(IMappingExpression<TEntity, TDTO> mapping)
        {
        }

        public virtual void CustomMappingsReverse(IMappingExpression<TDTO, TEntity> mapping)
        {
        }
    }
}
