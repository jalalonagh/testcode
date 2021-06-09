using BusinessLayout.Configuration.Commands;
using Entities;
using Entities.Common;
using ManaAutoMapper.Models;
using Services;

namespace BusinessLayout.BaseBusinessLevel1.Phone.Command.UpdateFieldRangeAsync
{
    public class UpdateFieldRangeAsyncCommand<TEntity, TDTO, TSearch, TKey> : CommandBase<ServiceResult<TEntity>>
        where TEntity : BaseEntity, new()
        where TDTO : AutoMapperDTO<TDTO, TEntity, TKey>, new()
        where TSearch : BaseSearchEntity, new()
        where TKey : struct
    {
        public UpdateFieldRangeAsyncCommand(TDTO model, params string[] fields)
        {
            Model = model;
            Fields = fields;
        }

        public TDTO Model { get; }
        public string[] Fields { get; }
    }
}