using Common;
using Entities.SMS;
using Services.Base.Services;

namespace Services.Services.SMSService
{
    public class SMSServices : BaseService<SMS, SMSSearch>, ISMSServices, IScopedDependency
    {
        public IRepository<SMS, SMSSearch> repository { get; set; }

        public SMSServices(IRepository<SMS, SMSSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
