using Common;
using Data.Repositories;
using Entities.Transaction;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.TransactionService
{
    public class TransactionServices: BaseService<Transaction, TransactionSearch>, ITransactionServices, IScopedDependency
    {
        public IRepository<Transaction, TransactionSearch> repository { get; set; }

        public TransactionServices(IRepository<Transaction, TransactionSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
