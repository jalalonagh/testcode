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
    
    public partial class SalCntrct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalCntrct()
        {
            this.SalCntrctGds = new HashSet<SalCntrctGd>();
            this.SalInvcHes = new HashSet<SalInvcH>();
        }
    
        public string SalCntrct_Si { get; set; }
        public int SalCust_Si { get; set; }
        public string SalCntrctGrp_Si { get; set; }
        public string SalCntrct_Tp { get; set; }
        public Nullable<System.DateTime> SalCntrct_CDT { get; set; }
        public Nullable<System.DateTime> SalCntrct_SDT { get; set; }
        public Nullable<System.DateTime> SalCntrct_EDT { get; set; }
        public Nullable<decimal> SalCntrct_Prc { get; set; }
        public string SalCntrct_FileName { get; set; }
        public string SalCntrct_TechMan { get; set; }
        public Nullable<byte> SalCntrctSts_Si { get; set; }
        public decimal SalCntrct_PreRec { get; set; }
        public decimal SalCntrct_Satis { get; set; }
        public decimal SalCntrct_Annx { get; set; }
    
        public virtual SalCntrctGrp SalCntrctGrp { get; set; }
        public virtual SalCntrctSt SalCntrctSt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalCntrctGd> SalCntrctGds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcH> SalInvcHes { get; set; }
    }
}
