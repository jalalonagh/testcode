//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurEnqry
    {
        public int PurEnqry_Si { get; set; }
        public int PurVndr_Si { get; set; }
        public int InvGds_Si { get; set; }
        public int PurResp_Si { get; set; }
        public Nullable<System.DateTime> PurEnqry_DT { get; set; }
        public Nullable<decimal> PurEnqry_UntPrc { get; set; }
        public string PurEnqry_Tp { get; set; }
        public Nullable<int> PurOrdr_Si { get; set; }
    
        public virtual InvGd InvGd { get; set; }
        public virtual PurOrdr PurOrdr { get; set; }
        //public virtual PurVndr PurVndr { get; set; }
    }
}
