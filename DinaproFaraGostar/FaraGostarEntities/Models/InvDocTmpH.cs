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
    
    public partial class InvDocTmpH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvDocTmpH()
        {
            this.InvDocTmpDs = new HashSet<InvDocTmpD>();
            this.InvDocTmpHAttaches = new HashSet<InvDocTmpHAttach>();
        }
    
        public int InvDocTmpH_Si { get; set; }
        public Nullable<int> InvDocTmpH_Cu { get; set; }
        public string InvDocTmpH_Ds { get; set; }
        public Nullable<int> InvInvt_Si { get; set; }
        public Nullable<int> PurVndr_Si { get; set; }
        public string InvDocTmpH_Tp { get; set; }
        public Nullable<bool> InvDocTmpH_SentDoc { get; set; }
        public Nullable<int> SiSystem { get; set; }
        public Nullable<int> Row_Si { get; set; }
        public Nullable<int> InvDocTmpH_Cu2 { get; set; }
        public Nullable<System.DateTime> InvDocTmpH_Dm { get; set; }
        public string InvDocTmpH_StmpCUs { get; set; }
        public Nullable<byte> InvDocTmpH_Sts { get; set; }
        public string InvDocTmpH_ExpNo { get; set; }
        public string InvDocTmpH_Reference { get; set; }
        public Nullable<int> PurOrdBuyH_Si { get; set; }
        public string InvDocTmpH_StmpTim { get; set; }
        public Nullable<int> PurReqstH_Si { get; set; }
        public Nullable<byte> InvDocTmpH_Ref { get; set; }
        public Nullable<int> PurchaseSendID { get; set; }
        public string InvDocTmpH_LoginEdit { get; set; }
        public Nullable<System.DateTime> InvDocTmpH_DsEdit { get; set; }
        public string InvDocTmpH_DlvBuy { get; set; }
        public string InvDocTmpH_CarNo { get; set; }
        public string InvDocTmpH_DlvLoc { get; set; }
        public string BarNumber { get; set; }
        public string DescDriver { get; set; }
        public Nullable<int> SalDriver_Si { get; set; }
        public Nullable<int> InvDocH_Good { get; set; }
        public Nullable<int> InvTyp_Si { get; set; }
        public Nullable<int> PerPrsnl_Si_2 { get; set; }
        public string InvDocTmpH_PurName { get; set; }
        public Nullable<int> InvRqstH_Si { get; set; }
        public Nullable<bool> InvDocTmpH_Lock { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDocTmpD> InvDocTmpDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDocTmpHAttach> InvDocTmpHAttaches { get; set; }
    }
}
