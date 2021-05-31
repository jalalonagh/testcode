using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.ConfirmedTransaction
{
    internal class ConfirmedTransactionDTOConfiguration : BaseDTO<ConfirmedTransactionDTO, Entities.ConfirmedTransaction.ConfirmedTransaction, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.ConfirmedTransaction.ConfirmedTransaction, ConfirmedTransactionDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}