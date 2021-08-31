using ManaBaseEntity.Common;
using System.Collections.Generic;

namespace Entities.Phone
{
    public class Phone : BaseEntity, IEntity
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public int? type { get; set; }
        public int? financialAccountId { get; set; }
    }
}
