using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Phone
{
    internal class PhoneDTOConfiguration : BaseDTO<PhoneDTO, Entities.Phone.Phone, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Phone.Phone, PhoneDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}