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
    
    public partial class CntReference
    {
        public int CntReference_Si { get; set; }
        public int CntContract_Si { get; set; }
        public Nullable<int> CntContract_Si_2 { get; set; }
        public string CntReference_Tx { get; set; }
        public Nullable<int> CntReferenceTyp_Si { get; set; }
    
        public virtual CntContract CntContract { get; set; }
        public virtual CntReferenceTyp CntReferenceTyp { get; set; }
    }
}
