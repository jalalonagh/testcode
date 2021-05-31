using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Entities.SMS
{
    public class SMS : BaseEntity
    {
        public string phone { get; set; }
        public string smsText { get; set; }
    }
}