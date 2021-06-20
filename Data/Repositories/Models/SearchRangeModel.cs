using ManaBaseEntity.Common;

namespace Data.Repositories.Models
{
    public class SearchRangeModel<TEntity> : RangeModel
        where TEntity : class, IEntity
    {
        public TEntity Entity { get; set; }
        public string Text { get; set; }
    }
}
