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
    
    public partial class InvGdsAccC
    {
        public int InvGds_Si { get; set; }
        public int AccLC_Si { get; set; }
        public int AccLM_Si { get; set; }
        public Nullable<int> AccLT_Si { get; set; }
    
        public virtual CtbAccM CtbAccM { get; set; }
        public virtual CtbAccT CtbAccT { get; set; }
        public virtual CtbCost CtbCost { get; set; }
        public virtual InvGd InvGd { get; set; }
    }
}
