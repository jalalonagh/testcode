using Common;
using Entities.Phone;
using ManaBaseData.Repositories;
using Services.Base.Services;

namespace Services.Services.PhoneService
{
    public class PhoneServices : BaseService<Phone, PhoneSearch>, IPhoneServices, IScopedDependency
    {
        public IRepository<Phone, PhoneSearch> repository { get; set; }

        public PhoneServices(IRepository<Phone, PhoneSearch> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
