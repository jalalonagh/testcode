using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories.Models
{
    public class SearchRangeModel<TEntity>: RangeModel
        where TEntity : class, IEntity
    {
        public TEntity Entity { get; set; }
        public string Text { get; set; }
    }
}
