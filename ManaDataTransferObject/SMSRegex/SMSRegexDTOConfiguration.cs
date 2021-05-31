using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMSRegex
{
    internal class SMSRegexDTOConfiguration : BaseDTO<SMSRegexDTO, Entities.SMSRegex.SMSRegex, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.SMSRegex.SMSRegex, SMSRegexDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}