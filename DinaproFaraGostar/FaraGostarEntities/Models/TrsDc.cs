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
    
    public partial class TrsDc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrsDc()
        {
            this.TrsDcAttaches = new HashSet<TrsDcAttach>();
            this.TrsDcCs = new HashSet<TrsDcC>();
            this.TrsDocVchrs = new HashSet<TrsDocVchr>();
            this.TrsDocVchrHs = new HashSet<TrsDocVchrH>();
        }
    
        public int TrsDc_Si { get; set; }
        public Nullable<int> TrsDc_Cu { get; set; }
        public short TrsDcTyp_Si { get; set; }
        public System.DateTime TrsDc_DT { get; set; }
        public Nullable<int> TrsDcGrp_Si { get; set; }
        public string TrsDc_Tp { get; set; }
        public bool TrsDc_Share { get; set; }
        public string StmpCUs { get; set; }
        public Nullable<System.DateTime> StmpCDT { get; set; }
        public Nullable<byte> CtbMnth_Si { get; set; }
        public Nullable<int> trsdc_cu2 { get; set; }
        public Nullable<System.DateTime> TrsDc_StmpCDT { get; set; }
        public string TrsDc_StmpTime { get; set; }
        public string TrsDc_StmpTimeEdit { get; set; }
        public Nullable<System.DateTime> TrsDc_StmpMDT { get; set; }
        public string StmpMUs { get; set; }
        public Nullable<bool> TrsDc_TransDB { get; set; }
    
        public virtual CtbMnth CtbMnth { get; set; }
        public virtual TrsDcGrp TrsDcGrp { get; set; }
        public virtual TrsDcTyp TrsDcTyp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsDcAttach> TrsDcAttaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsDcC> TrsDcCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsDocVchr> TrsDocVchrs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsDocVchrH> TrsDocVchrHs { get; set; }
    }
}
