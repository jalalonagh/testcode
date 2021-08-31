using BaseBusiness;
using Common;
using Entities.Phone;
using ManaDataTransferObject.Phone;
using Services.Base.Contracts;

namespace Services.Services.PhoneService
{
    public class PhoneCrud : Crud<Entities.Phone.Phone, PhoneSearch, PhoneDTO, int>, IPhoneCrud, IScopedDependency
    {
        public IBaseService<Phone, PhoneSearch> service { get; set; }

        public PhoneCrud(IBaseService<Phone, PhoneSearch> _service) : base(_service)
        {
            this.service = _service;
        }
    }
}
