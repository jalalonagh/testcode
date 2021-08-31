using FluentValidation;
using ManaBaseEntity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaEntitiesValidation.Extensions
{
    public static class EntityValidation
    {
        public static bool Validate<TEntity, TValid>(this TEntity entity, TValid valid)
            where TEntity : BaseEntity, new()
            where TValid : AbstractValidator<TEntity>, new()
        {
            if (valid.Validate(entity).IsValid)
                return true;
            return false;
        }

        public static bool Validate<TEntity, TValid>(this IEnumerable<TEntity> entities, TValid valid)
            where TEntity : BaseEntity, new()
            where TValid : AbstractValidator<TEntity>
        {
            if (entities != null && entities.Any())
                foreach (var item in entities)
                {
                    if (!valid.Validate(item).IsValid)
                        return false;
                }
            return true;
        }
    }
}
