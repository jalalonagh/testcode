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
    
    public partial class PurInvcH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurInvcH()
        {
            this.PurInvcDs = new HashSet<PurInvcD>();
            this.PurOrdrs = new HashSet<PurOrdr>();
        }
    
        public int PurInvcH_Si { get; set; }
        public System.DateTime PurInvcH_DT { get; set; }
        public int PurVndr_Si { get; set; }
        public int PurResp_Si { get; set; }
        public Nullable<int> PurInvcH_SCu { get; set; }
        public Nullable<System.DateTime> PurInvcH_SDT { get; set; }
        public string PurInvcH_Tp { get; set; }
        public decimal PurInvcH_Prc_Total { get; set; }
        public bool PurInvcH_AccDoc { get; set; }
        public string PurInvcH_StmpCUs { get; set; }
        public Nullable<System.DateTime> PurInvcH_StmpCDT { get; set; }
        public string PurInvcH_StmpMUs { get; set; }
        public Nullable<System.DateTime> PurInvcH_StmpMDT { get; set; }
        public Nullable<int> InvInvt_Si { get; set; }
        public Nullable<int> InvDocH_Si { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurInvcD> PurInvcDs { get; set; }
        //public virtual PurVndr PurVndr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurOrdr> PurOrdrs { get; set; }
    }
}
