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
    
    public partial class CntSrv
    {
        public int CntSrv_Si { get; set; }
        public int CntContract_Si { get; set; }
        public string CntSrv_Tx { get; set; }
        public Nullable<double> CntSrv_Quantity { get; set; }
        public string CntSrv_MeasureUnit { get; set; }
        public Nullable<decimal> CntSrv_UnitPrice { get; set; }
        public string CntSrv_Comment { get; set; }
    
        public virtual CntContract CntContract { get; set; }
    }
}
