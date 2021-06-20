using ManaBaseEntity.Common;

namespace Entities.ConfirmedTransaction
{
    public class ConfirmedTransactionSearch : BaseSearchEntity
    {
        public ConfirmedTransactionSearch()
        {

        }

        public int? transactionId { get; set; }
        public int? phoneId { get; set; }
        public bool? autoConfirmed { get; set; }
        public bool? manualConfirmed { get; set; }
    }
}
