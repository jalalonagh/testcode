using Entities.SMSConfirmation;
using Services.Base.Contracts;

namespace Services.Services.SMSConfirmationService
{
    public interface ISMSConfirmationServices : IBaseService<SMSConfirmation, SMSConfirmationSearch>
    {
    }
}
