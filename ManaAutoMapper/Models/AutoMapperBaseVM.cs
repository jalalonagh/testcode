using AutoMapper;
using ManaBaseEntity.Common;

namespace ManaAutoMapper.Models
{
    public class AutoMapperBaseVM<TVM, TEntity, TKey> : JsonVM<TVM, TEntity, TKey>
        where TVM : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
        public AutoMapperBaseVM()
        {

        }

        protected TVM CastToDerivedClass(AutoMapperInterfaceVM<TVM, TEntity, TKey> baseInstance)
        {
            var mapper = LazySingletonVM.SetCustomAssembly(typeof(TVM).Assembly);

            return mapper.GetMapper().Map<TVM>(baseInstance);
        }

        public void CreateMappings(AutoMapper.Profile profile)
        {
            var mappingExpression = profile.CreateMap<TVM, TEntity>();
            var mappingExpressionReverse = profile.CreateMap<TEntity, TVM>();

            var dtoType = typeof(TVM);
            var entityType = typeof(TEntity);

            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CustomMappings(mappingExpressionReverse);
            CustomMappingsReverse(mappingExpression);
        }

        public virtual void CustomMappings(IMappingExpression<TEntity, TVM> mapping)
        {
        }

        public virtual void CustomMappingsReverse(IMappingExpression<TVM, TEntity> mapping)
        {
        }
    }
}
