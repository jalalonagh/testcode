using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories.Models
{
    public abstract class RangeModel
    {
        public CancellationToken Cancel { get; set; } = new CancellationToken();
        public int Total { get; set; } = 0;
        public int More { get; set; } = int.MaxValue;
    }
}
