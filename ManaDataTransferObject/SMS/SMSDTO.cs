using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMS
{
    public class SMSDTO : BaseDTO<SMSDTO, Entities.SMS.SMS, int>
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}