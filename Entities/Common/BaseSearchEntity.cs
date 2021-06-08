using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common
{
    public interface ISearchEntity
    {
        public int? Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class BaseSearchEntity : ISearchEntity
    {
        public int? Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatePersianTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string LastUpdatePersianTime { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
