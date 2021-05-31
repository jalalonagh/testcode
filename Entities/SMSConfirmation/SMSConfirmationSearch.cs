using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SMSConfirmation
{
    public class SMSConfirmationSearch: BaseSearchEntity
    {
        public int? phoneId { get; set; }
        public int? smsId { get; set; }
        public string confirmationText { get; set; }
    }
}
