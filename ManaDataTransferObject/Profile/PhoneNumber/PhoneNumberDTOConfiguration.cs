using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile.PhoneNumber
{
    internal class PhoneNumberDTOConfiguration : BaseDTO<PhoneNumberDTO, Entities.Profile.PhoneNumber.PhoneNumber, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.PhoneNumber.PhoneNumber, PhoneNumberDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}