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
    
    public partial class InvVchrCodeMap
    {
        public int InvVchrCodeMap_Id { get; set; }
        public Nullable<int> AccLM_Si_Source { get; set; }
        public Nullable<int> AccLT_Si_Source { get; set; }
        public Nullable<int> AccLC_Si_Source { get; set; }
        public Nullable<int> AccLP_Si_Source { get; set; }
        public Nullable<int> AccLM_Si_Dest { get; set; }
        public Nullable<int> AccLT_Si_Dest { get; set; }
        public Nullable<int> AccLC_Si_Dest { get; set; }
        public Nullable<int> AccLP_Si_Dest { get; set; }
    
        public virtual CtbAccM CtbAccM { get; set; }
        public virtual CtbAccT CtbAccT { get; set; }
        public virtual CtbCost CtbCost { get; set; }
        public virtual CtbProject CtbProject { get; set; }
    }
}
