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
    
    public partial class InvGdsTyp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvGdsTyp()
        {
            this.InvDocDSrls = new HashSet<InvDocDSrl>();
            this.SalDclrPrcDs = new HashSet<SalDclrPrcD>();
        }
    
        public int InvGds_Si { get; set; }
        public int InvGdsTyp_Si { get; set; }
        public string InvGdsTyp_Tp { get; set; }
        public int InvUnt_Si { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvDocDSrl> InvDocDSrls { get; set; }
        public virtual InvUnt InvUnt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalDclrPrcD> SalDclrPrcDs { get; set; }
    }
}