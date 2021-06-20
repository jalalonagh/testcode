using ManaBaseEntity.Common;

namespace Data.Repositories.Models
{
    public class FilterRangeModel<TSearchEntity> : RangeModel
        where TSearchEntity : class, ISearchEntity
    {
        public TSearchEntity Entity { get; set; }
    }
}
