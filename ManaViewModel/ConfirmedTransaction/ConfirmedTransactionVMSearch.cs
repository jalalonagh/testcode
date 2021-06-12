using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaDataTransferObject.ConfirmedTransaction
{
    public class ConfirmedTransactionVMSearch : BaseSearchVM<ConfirmedTransactionVMSearch, Entities.ConfirmedTransaction.ConfirmedTransactionSearch, int>
    {
        public int? transactionId { get; set; }
        public int? phoneId { get; set; }
        public bool? autoConfirmed { get; set; }
        public bool? manualConfirmed { get; set; }
    }
}
