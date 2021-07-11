using ManaAutoMapper.Models;
using ManaBaseEntity.Common;

namespace ManaViewModel.Common
{
    public abstract class BaseSearchVM<TVM, TEntity, TKey> : AutoMapperSearchJsonVM<TVM, TEntity, TKey>
        where TVM : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {
    }
}
