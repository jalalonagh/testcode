using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Transaction
{
    internal class TransactionVMConfiguration : BaseVM<TransactionVM, Entities.Transaction.Transaction, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Transaction.Transaction, TransactionVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}