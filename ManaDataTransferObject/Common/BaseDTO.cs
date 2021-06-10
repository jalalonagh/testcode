using Entities.Common;
using ManaAutoMapper.Models;

namespace ManaDataTransferObject.Common
{
    public class BaseDTO<TDTO, TEntity, TKey> : AutoMapperDTO<TDTO, TEntity, TKey>
        where TDTO : class, new()
        where TEntity : BaseEntity, new()
        where TKey : struct
    {
    }
}