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
    
    public partial class TrsVchrH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrsVchrH()
        {
            this.TrsVchrDs = new HashSet<TrsVchrD>();
        }
    
        public int TrsVchrH_Id { get; set; }
        public Nullable<System.DateTime> TrsVchrH_Date { get; set; }
        public Nullable<System.DateTime> TrsVchrH_DateFrom { get; set; }
        public Nullable<System.DateTime> TrsVchrH_DateUntil { get; set; }
        public string TrsVchrH_Tx { get; set; }
        public bool TrsVchrH_Sent { get; set; }
        public Nullable<int> AccDocH_Si { get; set; }
    
        public virtual AccHDoc AccHDoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrsVchrD> TrsVchrDs { get; set; }
    }
}