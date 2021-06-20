using ManaBaseEntity.Common;

namespace Entities.SMSConfirmation
{
    public class SMSConfirmationSearch : BaseSearchEntity
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
