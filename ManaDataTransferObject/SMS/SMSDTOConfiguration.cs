using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMS
{
    internal class SMSDTOConfiguration : BaseDTO<SMSDTO, Entities.SMS.SMS, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMS.SMS, SMSDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}