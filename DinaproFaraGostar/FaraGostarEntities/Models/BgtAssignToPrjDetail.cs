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
    
    public partial class BgtAssignToPrjDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgtAssignToPrjDetail()
        {
            this.BgtAssignToPrjSubDetails = new HashSet<BgtAssignToPrjSubDetail>();
        }
    
        public int BgtAssignToPrjDetail_Si { get; set; }
        public Nullable<int> BgtAssignToPrj_Si { get; set; }
        public Nullable<decimal> BgtAssignToPrjDetail_Amnt { get; set; }
        public Nullable<System.DateTime> BgtAssignToPrjDetail_Date { get; set; }
        public string BgtAssignToPrjDetail_Desc { get; set; }
        public string BgtAssignToPrjDetail_Cu { get; set; }
        public Nullable<int> SiAccM { get; set; }
    
        public virtual BgtAssignToPrj BgtAssignToPrj { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgtAssignToPrjSubDetail> BgtAssignToPrjSubDetails { get; set; }
    }
}