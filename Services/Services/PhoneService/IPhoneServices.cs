using Entities.Phone;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PhoneService
{
    public interface IPhoneServices: IBaseService<Phone, PhoneSearch>
    {
    }
}
