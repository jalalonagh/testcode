using AutoMapper;
using Entities;
using ManaAutoMapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaAutoMapper.Models
{
    public class AutoMapperBaseDTO<TDto, TEntity, TKey> : JsonDTO<TDto, TEntity, TKey>, IHaveCustomMapping
        where TDto : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
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
