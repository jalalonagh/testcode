using Entities.Common;
using ManaEnums.Entity.Financial.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Transaction
{
    public class TransactionSearch: BaseSearchEntity
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public decimal? transaction { get; set; }
        public FinancialTransactionType? type { get; set; }
    }
}
