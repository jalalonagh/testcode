using Common;
using Data.Repositories;
using Entities.SMS;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.SMSService
{
    public class SMSServices: BaseService<SMS, SMSSearch>, ISMSServices, IScopedDependency
    {
        public IRepository<SMS, SMSSearch> repository { get; set; }

        public SMSServices(IRepository<SMS, SMSSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
