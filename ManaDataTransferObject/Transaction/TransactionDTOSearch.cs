using ManaDataTransferObject.Common;
using ManaEnums.Entity.Financial.Transaction;

namespace ManaDataTransferObject.Transaction
{
    public class TransactionDTOSearch : BaseSearchDTO<TransactionDTOSearch, Entities.Transaction.TransactionSearch, int>
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public decimal? transaction { get; set; }
        public FinancialTransactionType? type { get; set; }
    }
}
