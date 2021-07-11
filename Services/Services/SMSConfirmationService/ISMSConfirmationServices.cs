using Entities.SMSConfirmation;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.SMSConfirmationService
{
    public interface ISMSConfirmationServices: IBaseService<SMSConfirmation, SMSConfirmationSearch>
    {
    }
}
