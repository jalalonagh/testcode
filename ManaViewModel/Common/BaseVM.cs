using Entities.Common;
using ManaAutoMapper.Models;

namespace ManaViewModel.Common
{
    public class BaseVM<TVM, TEntity, TKey> : AutoMapperVM<TVM, TEntity, TKey>
        where TVM : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
    }
}