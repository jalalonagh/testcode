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
    
    public partial class PerPrsnl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PerPrsnl()
        {
            this.AstAssets = new HashSet<AstAsset>();
            this.PerAdvs = new HashSet<PerAdv>();
            this.PerBoxes = new HashSet<PerBox>();
            this.PerCmds = new HashSet<PerCmd>();
            this.PerGifts = new HashSet<PerGift>();
            this.PerIncDecs = new HashSet<PerIncDec>();
            this.PerLoans = new HashSet<PerLoan>();
            this.PerPrsnlAttaches = new HashSet<PerPrsnlAttach>();
            this.PerWrkLsts = new HashSet<PerWrkLst>();
        }
    
        public int PerPrsnl_Si { get; set; }
        public string PerPrsnl_Cu { get; set; }
        public string PerPrsnl_FName { get; set; }
        public string PerPrsnl_LName { get; set; }
        public bool PerPrsnl_Act { get; set; }
        public Nullable<int> CtbOrgPst_Si { get; set; }
        public Nullable<int> CtbOrgDep_Si { get; set; }
        public Nullable<int> CtbOrgJob_Si { get; set; }
        public string PerPrsnl_StmpCUs { get; set; }
        public Nullable<System.DateTime> PerPrsnl_StmpCDT { get; set; }
        public string PerPrsnl_StmpMUs { get; set; }
        public Nullable<System.DateTime> PerPrsnl_StmpMDT { get; set; }
        public string PerPrsnl_StmpTimeEdit { get; set; }
        public string PerPrsnl_StmpTime { get; set; }
        public Nullable<bool> PerPrsnl_Attach { get; set; }
        public string PerPrsnl_IdNo { get; set; }
        public Nullable<double> PerPrsnl_Price { get; set; }
        public string PerPrsnl_Tp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AstAsset> AstAssets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerAdv> PerAdvs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerBox> PerBoxes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerCmd> PerCmds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerGift> PerGifts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerIncDec> PerIncDecs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerLoan> PerLoans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerPrsnlAttach> PerPrsnlAttaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerWrkLst> PerWrkLsts { get; set; }
    }
}