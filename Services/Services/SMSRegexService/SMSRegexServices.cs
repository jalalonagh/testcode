using Common;
using Entities.SMSRegex;
using Services.Base.Services;

namespace Services.Services.SMSRegexService
{
    public class SMSRegexServices : BaseService<SMSRegex, SMSRegexSearch>, ISMSRegexServices, IScopedDependency
    {
        public IRepository<SMSRegex, SMSRegexSearch> repository { get; set; }

        public SMSRegexServices(IRepository<SMSRegex, SMSRegexSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
