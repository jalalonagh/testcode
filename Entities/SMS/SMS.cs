using System.Collections.Generic;

namespace Entities.SMS
{
    public class SMS : BaseEntity
    {
        public string phone { get; set; }
        public string smsText { get; set; }
        public IEnumerable<Transaction.Transaction> Transactions { get; set; }
    }
}