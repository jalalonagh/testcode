using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMSConfirmation
{
    public class SMSConfirmationDTO : BaseDTO<SMSConfirmationDTO, Entities.SMSConfirmation.SMSConfirmation, int>, IHaveCustomMapping
    {
        public int phoneId { get; set; }
        public int smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
