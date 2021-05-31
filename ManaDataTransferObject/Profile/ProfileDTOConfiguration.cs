using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile
{
    internal class ProfileDTOConfiguration : BaseDTO<ProfileDTO, Entities.Profile.Profile, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.Profile, ProfileDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}