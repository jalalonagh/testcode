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
    
    public partial class PurIncDecFactorType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurIncDecFactorType()
        {
            this.PurIncDecFactors = new HashSet<PurIncDecFactor>();
            this.PurIncDecFactorHs = new HashSet<PurIncDecFactorH>();
        }
    
        public int PurIncDecFactorType_Si { get; set; }
        public string PurIncDecFactorType_Cu { get; set; }
        public string PurIncDecFactorType_Tp { get; set; }
        public Nullable<byte> PurIncDecFactorType_IncDecFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurIncDecFactor> PurIncDecFactors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurIncDecFactorH> PurIncDecFactorHs { get; set; }
    }
}
