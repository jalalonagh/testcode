using Common;
using Entities.ConfirmedTransaction;
using ManaBaseData.Repositories;
using Services.Base.Services;

namespace Services.Services.ConfirmedTransactionService
{
    public class ConfirmedTransactionServices : BaseService<ConfirmedTransaction, ConfirmedTransactionSearch>, IConfirmedTransactionServices, IScopedDependency
    {
        public IRepository<ConfirmedTransaction, ConfirmedTransactionSearch> repository { get; set; }

        public ConfirmedTransactionServices(IRepository<ConfirmedTransaction, ConfirmedTransactionSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
