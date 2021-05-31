using Entities.SMS;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.SMSService
{
    public interface ISMSServices: IBaseService<SMS, SMSSearch>
    {
    }
}
