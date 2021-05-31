using ManaEnums.Entity.Financial.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Transaction
{
    public class Transaction: BaseEntity
    {
        public int phoneId { get; set; }
        public Phone.Phone phone { get; set; }
        public int smsId { get; set; }
        public SMS.SMS sms { get; set; }
        public decimal transaction { get; set; }
        public FinancialTransactionType type { get; set; }
    }
}
