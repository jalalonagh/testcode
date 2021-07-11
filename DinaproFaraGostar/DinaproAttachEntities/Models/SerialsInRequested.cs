using System;
using System.Collections.Generic;
namespace DinaproAttachModels.Models
{
    public class SerialsInRequested
    {
        public int id { get; set; }
        public Nullable<int> RequestPrintLable_ID { get; set; }
        public string serials { get; set; }

        //public virtual RequestPrintLabel RequestPrintLabel { get; set; }
    }
}
