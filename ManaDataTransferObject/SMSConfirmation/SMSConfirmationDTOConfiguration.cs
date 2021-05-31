using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMSConfirmation
{
    internal class SMSConfirmationDTOConfiguration : BaseDTO<SMSConfirmationDTO, Entities.SMSConfirmation.SMSConfirmation, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMSConfirmation.SMSConfirmation, SMSConfirmationDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}