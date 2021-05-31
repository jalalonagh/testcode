using ManaDataTransferObject.Common;
using ManaEnums.Entity.Financial.Transaction;

namespace ManaDataTransferObject.Transaction
{
    public class TransactionDTO : BaseDTO<TransactionDTO, Entities.Transaction.Transaction, int>
    {
        public int phoneId { get; set; }
        public int smsId { get; set; }
        public decimal transaction { get; set; }
        public FinancialTransactionType type { get; set; }
    }
}
