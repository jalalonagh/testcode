using Entities.Transaction;
using Services.Base.Contracts;

namespace Services.Services.TransactionService
{
    public interface ITransactionServices : IBaseService<Transaction, TransactionSearch>
    {
    }
}
