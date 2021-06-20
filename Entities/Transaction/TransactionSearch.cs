using ManaBaseEntity.Common;

namespace Entities.Transaction
{
    public class TransactionSearch : BaseSearchEntity
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public decimal? transaction { get; set; }
        public int? type { get; set; }
    }
}
