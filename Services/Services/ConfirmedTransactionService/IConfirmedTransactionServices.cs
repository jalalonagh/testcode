using Entities.ConfirmedTransaction;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ConfirmedTransactionService
{
    public interface IConfirmedTransactionServices: IBaseService<ConfirmedTransaction, ConfirmedTransactionSearch>
    {
    }
}
