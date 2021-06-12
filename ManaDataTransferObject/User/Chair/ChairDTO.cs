using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Chair
{
    public class ChairDTO : BaseDTO<ChairDTO, Entities.User.Chair.Chair, int>, IHaveCustomMapping
    {
        public string Name { get; set; }
    }
}
