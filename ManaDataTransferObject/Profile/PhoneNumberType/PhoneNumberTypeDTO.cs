using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile.PhoneNumberType
{
    public class PhoneNumberTypeDTO : BaseDTO<PhoneNumberTypeDTO, Entities.Profile.PhoneNumberType.PhoneNumberType, int>
    {
        public string Description { get; set; }
    }
}