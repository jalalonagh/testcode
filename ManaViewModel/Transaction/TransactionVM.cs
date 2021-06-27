using ManaAutoMapper.Interfaces;
using ManaViewModel.Common;

namespace ManaViewModel.Transaction
{
    public class TransactionVM : BaseVM<TransactionVM, Entities.Transaction.Transaction, int>, IHaveCustomMapping
    {
        public int phoneId { get; set; }
        public Phone.PhoneVM phone { get; set; }
        public int smsId { get; set; }
        public SMS.SMSVM sms { get; set; }
        public decimal transaction { get; set; }
        public int type { get; set; }
    }
}
