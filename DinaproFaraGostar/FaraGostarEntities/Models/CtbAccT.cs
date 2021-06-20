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
    
    public partial class CtbAccT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CtbAccT()
        {
            this.AccARqsts = new HashSet<AccARqst>();
            this.AccBudgets = new HashSet<AccBudget>();
            this.AccDDocs = new HashSet<AccDDoc>();
            this.AstAssetSellings = new HashSet<AstAssetSelling>();
            this.CtbAccT2CtbAccM = new HashSet<CtbAccT2CtbAccM>();
            this.InvDocDs = new HashSet<InvDocD>();
            this.InvGdsAccCs = new HashSet<InvGdsAccC>();
            this.InvGdsAccPs = new HashSet<InvGdsAccP>();
            //this.InvInvts = new HashSet<InvInvt>();
            this.InvVchrCodeMaps = new HashSet<InvVchrCodeMap>();
            this.InvVchrDs = new HashSet<InvVchrD>();
            this.PerOprs = new HashSet<PerOpr>();
            this.PerPrsnlDs = new HashSet<PerPrsnlD>();
            this.PerVchrDs = new HashSet<PerVchrD>();
            //this.PurVndrs = new HashSet<PurVndr>();
            this.SalCusts = new HashSet<SalCust>();
            this.SalGdsAccs = new HashSet<SalGdsAcc>();
            this.SalGdsRetAccs = new HashSet<SalGdsRetAcc>();
            this.SalInvcOprs = new HashSet<SalInvcOpr>();
            this.SalInvcSrvOprs = new HashSet<SalInvcSrvOpr>();
            this.SalOprs = new HashSet<SalOpr>();
            this.SalPreInvcSrvOprs = new HashSet<SalPreInvcSrvOpr>();
            this.SalRetInvcOprs = new HashSet<SalRetInvcOpr>();
            this.SalSrvAccs = new HashSet<SalSrvAcc>();
            this.TrsAccs = new HashSet<TrsAcc>();
            this.TrsARqsts = new HashSet<TrsARqst>();
            this.TrsAsgns = new HashSet<TrsAsgn>();
            this.TrsChqPs = new HashSet<TrsChqP>();
            this.TrsDcAs = new HashSet<TrsDcA>();
            this.TrsRsrcs = new HashSet<TrsRsrc>();
            this.TrsVchrDs = new HashSet<TrsVchrD>();
        }
    
        public int SiAccT { get; set; }
        public string CuAcc { get; set; }
        public string TpAcc { get; set; }
        public int SiFather { get; set; }
        public string CmAcc { get; set; }
        public Nullable<System.DateTime> CreateRec { get; set; }
        public string LoginName { get; set; }
        public string TpAcc2 { get; set; }
        public Nullable<int> CuAcc2 { get; set; }
        public Nullable<int> Nature { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccARqst> AccARqsts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccBudget> AccBudgets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccDDoc> AccDDocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AstAssetSelling> AstAssetSellings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CtbAccT2CtbAccM> CtbAccT2CtbAccM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDocD> InvDocDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvGdsAccC> InvGdsAccCs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvGdsAccP> InvGdsAccPs { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<InvInvt> InvInvts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvVchrCodeMap> InvVchrCodeMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvVchrD> InvVchrDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerOpr> PerOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerPrsnlD> PerPrsnlDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerVchrD> PerVchrDs { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PurVndr> PurVndrs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalCust> SalCusts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalGdsAcc> SalGdsAccs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalGdsRetAcc> SalGdsRetAccs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcOpr> SalInvcOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcSrvOpr> SalInvcSrvOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalOpr> SalOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalPreInvcSrvOpr> SalPreInvcSrvOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalRetInvcOpr> SalRetInvcOprs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalSrvAcc> SalSrvAccs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsAcc> TrsAccs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsARqst> TrsARqsts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsAsgn> TrsAsgns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsChqP> TrsChqPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsDcA> TrsDcAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsRsrc> TrsRsrcs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsVchrD> TrsVchrDs { get; set; }
    }
}