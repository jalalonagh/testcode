using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Transaction
{
    internal class TransactionDTOConfiguration : BaseDTO<TransactionDTO, Entities.Transaction.Transaction, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Transaction.Transaction, TransactionDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}