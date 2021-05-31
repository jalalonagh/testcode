using Common;
using Data.Repositories;
using Entities.SMSConfirmation;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.SMSConfirmationService
{
    public class SMSConfirmationServices: BaseService<SMSConfirmation, SMSConfirmationSearch>, ISMSConfirmationServices, IScopedDependency
    {
        public IRepository<SMSConfirmation, SMSConfirmationSearch> repository { get; set; }

        public SMSConfirmationServices(IRepository<SMSConfirmation, SMSConfirmationSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
