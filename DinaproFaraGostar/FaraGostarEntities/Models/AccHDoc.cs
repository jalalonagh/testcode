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
    
    public partial class AccHDoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccHDoc()
        {
            this.AccDDocs = new HashSet<AccDDoc>();
            this.AccDocHAttacHes = new HashSet<AccDocHAttacH>();
            this.InvVchrHs = new HashSet<InvVchrH>();
            this.PerPyrlPeriods = new HashSet<PerPyrlPeriod>();
            this.SalVchrHs = new HashSet<SalVchrH>();
            this.TrsVchrHs = new HashSet<TrsVchrH>();
        }
    
        public int SiHDoc { get; set; }
        public Nullable<int> CuDoc { get; set; }
        public string TpHDoc { get; set; }
        public Nullable<System.DateTime> DsDoc { get; set; }
        public string CmDoc { get; set; }
        public Nullable<bool> TempDoc { get; set; }
        public Nullable<int> SiDocType { get; set; }
        public Nullable<int> SecCuDoc { get; set; }
        public Nullable<int> SiDefinite { get; set; }
        public Nullable<int> SiSystem { get; set; }
        public string TpCreator { get; set; }
        public string TpConfirmation { get; set; }
        public Nullable<System.DateTime> CreateRec { get; set; }
        public string LoginName { get; set; }
        public string TpHDoc2 { get; set; }
        public Nullable<int> AccLoc_Si { get; set; }
        public Nullable<byte> Flag { get; set; }
        public Nullable<int> SiHDoc_Source { get; set; }
        public Nullable<bool> ExchangeDocCtrl { get; set; }
        public Nullable<bool> ExchangeDocFlag { get; set; }
        public Nullable<int> IdVocherDate { get; set; }
        public Nullable<bool> IsLock { get; set; }
        public string UserLock { get; set; }
        public string GuId { get; set; }
        public Nullable<int> PerLoc_Si { get; set; }
        public Nullable<int> MonthH { get; set; }
        public Nullable<System.DateTime> AccHDoc_StmpCDT { get; set; }
        public string AccHDoc_StmpTime { get; set; }
        public string AccHDoc_StmpTimeEdit { get; set; }
        public Nullable<System.DateTime> AccHDoc_StmpMDT { get; set; }
        public Nullable<int> PaymentPeriodId { get; set; }
        public Nullable<int> DepositTypeId { get; set; }
        public Nullable<int> LoanTypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccDDoc> AccDDocs { get; set; }
        public virtual AccDocDefinite AccDocDefinite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccDocHAttacH> AccDocHAttacHes { get; set; }
        public virtual AccDocType AccDocType { get; set; }
        public virtual AccLoc AccLoc { get; set; }
        public virtual FaraSystem FaraSystem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvVchrH> InvVchrHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerPyrlPeriod> PerPyrlPeriods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalVchrH> SalVchrHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsVchrH> TrsVchrHs { get; set; }
    }
}
