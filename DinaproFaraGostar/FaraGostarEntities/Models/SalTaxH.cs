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
    
    public partial class SalTaxH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalTaxH()
        {
            this.SalTaxDs = new HashSet<SalTaxD>();
        }
    
        public int SalTaxH_Si { get; set; }
        public string SalTaxH_Ds { get; set; }
        public string SalTaxH_Tp { get; set; }
        public Nullable<bool> SalTaxH_Act { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalTaxD> SalTaxDs { get; set; }
    }
}
