using ManaAutoMapper.Models;
using ManaBaseEntity.Common;

namespace ManaDataTransferObject.Common
{
    public abstract class BaseSearchDTO<TDTO, TEntity, TKey> : AutoMapperJsonDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : BaseSearchEntity, new()
        where TKey : struct
    {
    }
}
