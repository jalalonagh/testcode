using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.User.Chair
{
    public class ChairDTO : BaseDTO<ChairDTO, Entities.User.Chair.Chair, int>
    {
        public string Name { get; set; }
    }
}
