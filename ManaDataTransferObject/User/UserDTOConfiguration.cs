using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User
{
    internal class UserDTOConfiguration : BaseInterfaceDTO<UserDTO, Entities.User.User, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.User, UserDTO> mapping)
        {

        }
    }
}