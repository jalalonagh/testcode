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
    
    public partial class PrdcTraceDMaterial
    {
        public int PrdcTraceDMaterial_Si { get; set; }
        public Nullable<int> PrdcTraceDInfo_Si { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public Nullable<double> PrdcTraceDMaterial_Value { get; set; }
        public Nullable<int> PrdcWorkOrderDMaterial_Si { get; set; }
        public Nullable<int> PrdcTraceDMaterial_InvDocType { get; set; }
    
        public virtual InvGd InvGd { get; set; }
        public virtual PrdcTraceDInfo PrdcTraceDInfo { get; set; }
    }
}