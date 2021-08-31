using Entities.ConfirmedTransaction;
using Services.Base.Contracts;

namespace Services.Services.ConfirmedTransactionService
{
    public interface IConfirmedTransactionServices : IBaseService<ConfirmedTransaction, ConfirmedTransactionSearch>
    {
    }
}
