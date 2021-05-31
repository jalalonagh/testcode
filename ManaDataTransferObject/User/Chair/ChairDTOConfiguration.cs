using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Chair
{
    public class ChairDTOConfiguration : BaseDTO<ChairDTO, Entities.User.Chair.Chair, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.User.Chair.Chair, ChairDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}
