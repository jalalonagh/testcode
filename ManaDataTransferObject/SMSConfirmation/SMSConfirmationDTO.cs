using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMSConfirmation
{
    public class SMSConfirmationDTO : BaseDTO<SMSConfirmationDTO, Entities.SMSConfirmation.SMSConfirmation, int>
    {
        public int phoneId { get; set; }
        public int smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
