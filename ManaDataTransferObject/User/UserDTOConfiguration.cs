using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User
{
    public class UserDTOConfiguration : BaseInterfaceDTO<UserDTO, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}