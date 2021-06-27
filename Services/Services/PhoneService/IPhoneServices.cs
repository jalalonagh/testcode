using Entities.Phone;
using Services.Base.Contracts;

namespace Services.Services.PhoneService
{
    public interface IPhoneServices : IBaseService<Phone, PhoneSearch>
    {
    }
}
