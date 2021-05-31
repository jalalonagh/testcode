using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile.PhoneNumberType
{
    internal class PhoneNumberTypeDTOConfiguration : BaseDTO<PhoneNumberTypeDTO, Entities.Profile.PhoneNumberType.PhoneNumberType, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.PhoneNumberType.PhoneNumberType, PhoneNumberTypeDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}