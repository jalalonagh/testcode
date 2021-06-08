using Entities.Common;
using System.Collections.Generic;

namespace Entities.Profile
{
    public class ProfileSearch : BaseSearchEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string ExtensionNumber { get; set; }
    }
}