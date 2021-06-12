using Entities.Common;
using ManaEnums.Entity.Financial.Transaction;
using System.Collections.Generic;

namespace Entities.Transaction
{
    public class Transaction : BaseEntity
    {
        public int phoneId { get; set; }
        public Phone.Phone phone { get; set; }
        public int smsId { get; set; }
        public SMS.SMS sms { get; set; }
        public decimal transaction { get; set; }
        public int type { get; set; }
        public IEnumerable<ConfirmedTransaction.ConfirmedTransaction> Confirms { get; set; }
    }
}
