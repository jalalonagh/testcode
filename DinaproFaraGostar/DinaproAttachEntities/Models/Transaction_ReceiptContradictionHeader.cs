//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction_ReceiptContradictionHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction_ReceiptContradictionHeader()
        {
            this.Transaction_ReceiptContradictionDetail = new HashSet<Transaction_ReceiptContradictionDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> InvDocH_Cu { get; set; }
        public string User { get; set; }
        public string Ds { get; set; }
        public Nullable<System.DateTime> Dm { get; set; }
        public Nullable<bool> Solved { get; set; }
        public string Transaction_InvInvt_Cu { get; set; }
        public string Receipt_InvInvt_Cu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction_ReceiptContradictionDetail> Transaction_ReceiptContradictionDetail { get; set; }
    }
}