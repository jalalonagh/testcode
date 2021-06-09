using ManaEnums.Entity.Phone;
using System.Collections.Generic;

namespace Entities.Phone
{
    public class Phone : BaseEntity
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public PhoneType? type { get; set; }
        public int? financialAccountId { get; set; }
        public IEnumerable<ConfirmedTransaction.ConfirmedTransaction> Confirms { get; set; }
        public IEnumerable<Transaction.Transaction> Transactions { get; set; }
    }
}
