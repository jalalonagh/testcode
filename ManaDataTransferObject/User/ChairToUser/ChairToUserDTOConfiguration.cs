using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.ChairToUser
{
    public class ChairToUserDTOConfiguration : BaseDTO<ChairToUserDTO, Entities.User.ChairToUser.ChairToUser, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.ChairToUser.ChairToUser, ChairToUserDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
