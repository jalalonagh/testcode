using ManaAutoMapper.Models;

namespace ManaViewModel.Common
{
    public abstract class BaseInterfaceVM<TDTO, TEntity, TKey> : AutoMapperInterfaceVM<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
    }
}