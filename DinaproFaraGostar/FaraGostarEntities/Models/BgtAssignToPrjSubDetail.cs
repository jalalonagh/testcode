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
    
    public partial class BgtAssignToPrjSubDetail
    {
        public int BgtAssignToPrjSubDetail_Si { get; set; }
        public Nullable<int> BgtAssignToPrjDetail_Si { get; set; }
        public Nullable<decimal> BgtAssignToPrjSubDetail_Amnt { get; set; }
        public Nullable<System.DateTime> BgtAssignToPrjSubDetail_Date { get; set; }
        public string BgtAssignToPrjSubDetail_Desc { get; set; }
        public Nullable<int> RequestId { get; set; }
    
        public virtual BgtAssignToPrjDetail BgtAssignToPrjDetail { get; set; }
    }
}