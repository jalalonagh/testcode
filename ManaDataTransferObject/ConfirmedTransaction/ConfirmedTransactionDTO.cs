using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.ConfirmedTransaction
{
    public class ConfirmedTransactionDTO : BaseDTO<ConfirmedTransactionDTO, Entities.ConfirmedTransaction.ConfirmedTransaction, int>, IHaveCustomMapping
    {
        public ConfirmedTransactionDTO()
        {

        }

        public int transactionId { get; set; }
        public int phoneId { get; set; }
        public bool? autoConfirmed { get; set; }
        public bool? manualConfirmed { get; set; }
    }
}
