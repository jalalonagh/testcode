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
    
    public partial class CntAlert
    {
        public int CntAlert_Si { get; set; }
        public int CntContract_Si { get; set; }
        public string CntAlert_Date { get; set; }
        public string CntAlert_Tx { get; set; }
        public Nullable<bool> CntAlert_Dismiss { get; set; }
        public Nullable<int> CntTask_Si { get; set; }
        public Nullable<int> CntAlert_DayBeforeAlert { get; set; }
        public Nullable<int> CntAlert_PrgssBeforeAlert { get; set; }
        public Nullable<short> CntAlert_Typ { get; set; }
    
        public virtual CntContract CntContract { get; set; }
    }
}
