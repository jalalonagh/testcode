using ManaDataTransferObject.Common;
using ManaEnums.Entity.Phone;

namespace ManaDataTransferObject.Profile.PhoneNumber
{
    public class PhoneNumberDTO : BaseDTO<PhoneNumberDTO, Entities.Profile.PhoneNumber.PhoneNumber, int>
    {
        public PhoneNumberType.PhoneNumberTypeDTO PhoneNumberType { get; set; }
        public PhoneType PhoneNumberTypeId { get; set; }
        public string Number { get; set; }
    }
}