using Common;
using Entities.Transaction;
using Services.Base.Services;

namespace Services.Services.TransactionService
{
    public class TransactionServices : BaseService<Transaction, TransactionSearch>, ITransactionServices, IScopedDependency
    {
        public IRepository<Transaction, TransactionSearch> repository { get; set; }

        public TransactionServices(IRepository<Transaction, TransactionSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
