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
    
    public partial class AssServiceH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssServiceH()
        {
            this.AssServiceDs = new HashSet<AssServiceD>();
        }
    
        public int AssSrvH_Si { get; set; }
        public string AssSrvH_Cu { get; set; }
        public Nullable<System.DateTime> AssSrvH_Date { get; set; }
        public string AssSrvH_deliverer { get; set; }
        public string AssSrvH_wrong { get; set; }
        public string AssSrvH_Action { get; set; }
        public string AssSrvH_Note { get; set; }
        public Nullable<int> AssPrs_Si { get; set; }
        public Nullable<int> AssReception_Si { get; set; }
        public Nullable<bool> AssSrvH_OView { get; set; }
        public Nullable<bool> AssSrvH_lReq { get; set; }
        public Nullable<bool> AssSrvH_Install { get; set; }
        public Nullable<bool> AssSrvH_Educ { get; set; }
    
        public virtual AssReception AssReception { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssServiceD> AssServiceDs { get; set; }
    }
}