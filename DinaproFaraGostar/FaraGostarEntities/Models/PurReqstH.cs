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
    
    public partial class PurReqstH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurReqstH()
        {
            this.PurReqstDs = new HashSet<PurReqstD>();
        }
    
        public int PurReqstH_Si { get; set; }
        public Nullable<int> PurReqstH_Cu { get; set; }
        public Nullable<System.DateTime> PurReqstH_DT { get; set; }
        public string PurReqstH_Tp { get; set; }
        public string PurReqstH_Docno { get; set; }
        public Nullable<int> PurRqstCuse_Si { get; set; }
        public Nullable<int> PurReqstH_Applyer { get; set; }
        public Nullable<int> PurReqstH_Deliverst { get; set; }
        public Nullable<int> PurBuySt_Si { get; set; }
        public Nullable<bool> PurReqstH_OK { get; set; }
        public Nullable<byte> PurReqstH_Sts { get; set; }
        public Nullable<int> PurResp_Si { get; set; }
        public Nullable<int> PurReqstH_BuyKind { get; set; }
        public Nullable<int> PurReqstH_process { get; set; }
        public Nullable<int> PurReqstH_KindOrd { get; set; }
        public Nullable<int> PurchaseOrderID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurReqstD> PurReqstDs { get; set; }
    }
}
