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
    
    public partial class SalResp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalResp()
        {
            this.SalInvcHes = new HashSet<SalInvcH>();
            this.SalInvcSrvHs = new HashSet<SalInvcSrvH>();
            this.SalPreInvcHes = new HashSet<SalPreInvcH>();
            this.SalPreInvcSrvHs = new HashSet<SalPreInvcSrvH>();
            this.SalRequestHs = new HashSet<SalRequestH>();
            this.SalRespUsers = new HashSet<SalRespUser>();
        }
    
        public int SalResp_Si { get; set; }
        public string SalResp_Tp { get; set; }
        public string SalResp_Tel { get; set; }
        public string SalResp_Adrs { get; set; }
        public byte[] SalResp_Photo { get; set; }
        public string SalResp_Tp_En { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcH> SalInvcHes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalInvcSrvH> SalInvcSrvHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalPreInvcH> SalPreInvcHes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalPreInvcSrvH> SalPreInvcSrvHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalRequestH> SalRequestHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalRespUser> SalRespUsers { get; set; }
    }
}