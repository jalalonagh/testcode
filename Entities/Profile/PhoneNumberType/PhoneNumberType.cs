using ManaEnums.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Profile.PhoneNumberType
{
    public class PhoneNumberType : BaseEntity
    {
        public string Description { get; set; }
        public IEnumerable<PhoneNumber.PhoneNumber> PhoneNumbers { get; set; }
    }
}