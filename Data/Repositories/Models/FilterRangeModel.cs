using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories.Models
{
    public class FilterRangeModel<TSearchEntity>: RangeModel
        where TSearchEntity : class, ISearchEntity
    {
        public TSearchEntity Entity { get; set; }
    }
}
