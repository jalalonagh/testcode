using Common;
using Data.Repositories;
using Entities.Phone;
using Services.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PhoneService
{
    public class PhoneServices: BaseService<Phone, PhoneSearch>, IPhoneServices, IScopedDependency
    {
        public IRepository<Phone, PhoneSearch> repository { get; set; }

        public PhoneServices(IRepository<Phone, PhoneSearch> repository): base(repository)
        {
            this.repository = repository;
        }
    }
}
