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
    
    public partial class InvUnt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvUnt()
        {
            this.InvDocDs = new HashSet<InvDocD>();
            this.InvGds = new HashSet<InvGd>();
            this.InvGdsTyps = new HashSet<InvGdsTyp>();
            this.InvUntCnvrts = new HashSet<InvUntCnvrt>();
            this.InvUntRelateds = new HashSet<InvUntRelated>();
            this.SalDclrPrcDs = new HashSet<SalDclrPrcD>();
            this.SalePreInvoiceDetails = new HashSet<SalePreInvoiceDetail>();
            this.SalInvcDs = new HashSet<SalInvcD>();
            this.SalPreInvcDs = new HashSet<SalPreInvcD>();
            this.SalPreInvcSrvDs = new HashSet<SalPreInvcSrvD>();
            this.SalRequestDs = new HashSet<SalRequestD>();
            this.SalRetInvcDs = new HashSet<SalRetInvcD>();
        }
    
        public int InvUnt_Si { get; set; }
        public string InvUnt_Cu { get; set; }
        public string InvUnt_Tp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDocD> InvDocDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvGd> InvGds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvGdsTyp> InvGdsTyps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvUntCnvrt> InvUntCnvrts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvUntRelated> InvUntRelateds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalDclrPrcD> SalDclrPrcDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalePreInvoiceDetail> SalePreInvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcD> SalInvcDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalPreInvcD> SalPreInvcDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalPreInvcSrvD> SalPreInvcSrvDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalRequestD> SalRequestDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalRetInvcD> SalRetInvcDs { get; set; }
    }
}
