using ManaViewModel.Common;

namespace ManaViewModel.ConfirmedTransaction
{
    public class ConfirmedTransactionVM : BaseVM<ConfirmedTransactionVM, Entities.ConfirmedTransaction.ConfirmedTransaction, int>
    {
        public int transactionId { get; set; }
        public Transaction.TransactionVM transaction { get; set; }
        public int phoneId { get; set; }
        public Phone.PhoneVM phone { get; set; }
        public bool? autoConfirmed { get; set; }
        public bool? manualConfirmed { get; set; }
    }
}
