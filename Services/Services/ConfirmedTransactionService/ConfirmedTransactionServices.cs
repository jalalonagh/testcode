using Common;
using Data.Repositories;
using Entities.ConfirmedTransaction;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ConfirmedTransactionService
{
    public class ConfirmedTransactionServices: BaseService<ConfirmedTransaction, ConfirmedTransactionSearch>, IConfirmedTransactionServices, IScopedDependency
    {
        public IRepository<ConfirmedTransaction, ConfirmedTransactionSearch> repository { get; set; }

        public ConfirmedTransactionServices(IRepository<ConfirmedTransaction, ConfirmedTransactionSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
