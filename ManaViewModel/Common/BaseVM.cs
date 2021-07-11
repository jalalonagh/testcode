using ManaAutoMapper.Models;
using ManaBaseEntity.Common;

namespace ManaViewModel.Common
{
    public class BaseVM<TVM, TEntity, TKey> : AutoMapperVM<TVM, TEntity, TKey>
        where TVM : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
    }
}