using Common;
using Entities.SMSConfirmation;
using Services.Base.Services;

namespace Services.Services.SMSConfirmationService
{
    public class SMSConfirmationServices : BaseService<SMSConfirmation, SMSConfirmationSearch>, ISMSConfirmationServices, IScopedDependency
    {
        public IRepository<SMSConfirmation, SMSConfirmationSearch> repository { get; set; }

        public SMSConfirmationServices(IRepository<SMSConfirmation, SMSConfirmationSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
