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
    
    public partial class InvCostQcUser
    {
        public int InvCostQcUser_Si { get; set; }
        public Nullable<int> InvCostQc_Si { get; set; }
        public string UserRec { get; set; }
        public Nullable<bool> InvCostQcUser_Accept { get; set; }
    
        public virtual InvCostQc InvCostQc { get; set; }
    }
}