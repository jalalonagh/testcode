using ManaBaseEntity.Common;

namespace ManaBaseData.Repositories.Models
{
    public class SearchRangeModel<TEntity> : RangeModel
        where TEntity : class, IEntity
    {
        public TEntity Entity { get; set; }
        public string Text { get; set; }
    }
}
