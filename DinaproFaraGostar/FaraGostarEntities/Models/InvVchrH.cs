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
    
    public partial class InvVchrH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvVchrH()
        {
            this.InvVchrDs = new HashSet<InvVchrD>();
        }
    
        public int InvVchrH_Id { get; set; }
        public Nullable<System.DateTime> InvVchrH_Date { get; set; }
        public Nullable<System.DateTime> InvVchrH_DateFrom { get; set; }
        public Nullable<System.DateTime> InvVchrH_DateUntil { get; set; }
        public string InvVchrH_Tx { get; set; }
        public bool InvVchrH_Sent { get; set; }
        public Nullable<int> AccDocH_Si { get; set; }
        public Nullable<int> InvInvt_Si { get; set; }
        public Nullable<int> InvDocTyp_Si { get; set; }
    
        public virtual AccHDoc AccHDoc { get; set; }
        public virtual InvDocTyp InvDocTyp { get; set; }
        //public virtual InvInvt InvInvt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvVchrD> InvVchrDs { get; set; }
    }
}