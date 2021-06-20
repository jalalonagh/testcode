using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.ConfirmedTransaction
{
    public class ConfirmedTransactionDTOSearch : BaseSearchDTO<ConfirmedTransactionDTOSearch, Entities.ConfirmedTransaction.ConfirmedTransactionSearch, int>
    {
        public int? transactionId { get; set; }
        public int? phoneId { get; set; }
        public bool? autoConfirmed { get; set; }
        public bool? manualConfirmed { get; set; }
    }
}
