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
    
    public partial class PurRqstH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurRqstH()
        {
            this.PurRqstDs = new HashSet<PurRqstD>();
        }
    
        public int PurRqstH_Si { get; set; }
        public Nullable<System.DateTime> PurRqstH_DT { get; set; }
        public Nullable<int> CtbCost_Si { get; set; }
        public Nullable<int> PurRqstCuse_Si { get; set; }
        public Nullable<int> InvInvt_Si { get; set; }
        public Nullable<System.DateTime> PurRqstH_RDT { get; set; }
        public string PurRqstH_Tp { get; set; }
        public byte PurRqstHCnfrm_Si { get; set; }
        public string PurRqstH_CnfrmDesc { get; set; }
    
        public virtual CtbCost CtbCost { get; set; }
        //public virtual InvInvt InvInvt { get; set; }
        public virtual PurRqstCuse PurRqstCuse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurRqstD> PurRqstDs { get; set; }
        public virtual PurRqstHCnfrm PurRqstHCnfrm { get; set; }
    }
}
