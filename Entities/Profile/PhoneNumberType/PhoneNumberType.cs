using Entities.Common;
using System.Collections.Generic;

namespace Entities.Profile.PhoneNumberType
{
    public class PhoneNumberType : BaseEntity
    {
        public string Description { get; set; }
        public IEnumerable<PhoneNumber.PhoneNumber> PhoneNumbers { get; set; }
    }
}