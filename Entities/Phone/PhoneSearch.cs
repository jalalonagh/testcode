using Entities.Common;
using ManaEnums.Entity.Phone;

namespace Entities.Phone
{
    public class PhoneSearch : BaseSearchEntity
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public int? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
