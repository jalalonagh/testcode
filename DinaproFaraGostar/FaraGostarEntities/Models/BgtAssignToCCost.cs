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
    
    public partial class BgtAssignToCCost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgtAssignToCCost()
        {
            this.BgtAssignToCCostDetails = new HashSet<BgtAssignToCCostDetail>();
        }
    
        public int BgtAssignToCCost_Si { get; set; }
        public Nullable<int> BgtAssignAccM_Si { get; set; }
        public Nullable<decimal> BgtAssignToCCost_Amnt { get; set; }
        public Nullable<int> SiCost { get; set; }
        public Nullable<System.DateTime> BgtAssignToCCost_Date { get; set; }
    
        public virtual BgtAssignAccM BgtAssignAccM { get; set; }
        public virtual CtbCost CtbCost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgtAssignToCCostDetail> BgtAssignToCCostDetails { get; set; }
    }
}
