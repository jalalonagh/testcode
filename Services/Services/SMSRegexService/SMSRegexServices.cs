using Common;
using Data.Repositories;
using Entities.SMSRegex;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.SMSRegexService
{
    public class SMSRegexServices: BaseService<SMSRegex, SMSRegexSearch>, ISMSRegexServices, IScopedDependency
    {
        public IRepository<SMSRegex, SMSRegexSearch> repository { get; set; }

        public SMSRegexServices(IRepository<SMSRegex, SMSRegexSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
