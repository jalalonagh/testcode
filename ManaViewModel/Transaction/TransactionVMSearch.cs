using ManaViewModel.Common;

namespace ManaViewModel.Transaction
{
    public class TransactionVMSearch : BaseSearchVM<TransactionVMSearch, Entities.Transaction.TransactionSearch, int>
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public decimal? transaction { get; set; }
        public int? type { get; set; }
    }
}
