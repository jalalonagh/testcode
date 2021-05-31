using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMSConfirmation
{
    public class SMSConfirmationDTOSearch : BaseSearchDTO<SMSConfirmationDTOSearch, Entities.SMSConfirmation.SMSConfirmationSearch, int>
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
