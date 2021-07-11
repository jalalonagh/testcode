using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.SMS
{
    public class SMSDTOSearch : BaseSearchDTO<SMSDTO, Entities.SMS.SMSSearch, int>
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}