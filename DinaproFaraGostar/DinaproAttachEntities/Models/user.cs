//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rrrrrrrrrrrrrrrrrrr
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.ownerInvoices = new HashSet<ownerInvoice>();
            this.ownerStorages = new HashSet<ownerStorage>();
            this.userToInvInvts = new HashSet<userToInvInvt>();
            this.userToSalBrnches = new HashSet<userToSalBrnch>();
            this.userToSalIntrmds = new HashSet<userToSalIntrmd>();
            this.userToSalResps = new HashSet<userToSalResp>();
            this.userToSalTyps = new HashSet<userToSalTyp>();
            this.userToSalvarieties = new HashSet<userToSalvariety>();
        }
    
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime createdDate_Dm { get; set; }
        public string createdDate_Ds { get; set; }
        public Nullable<System.DateTime> updatedDate_Dm { get; set; }
        public string updatedDate_Ds { get; set; }
        public bool active { get; set; }
        public bool online { get; set; }
        public Nullable<int> SalResp_Si { get; set; }
        public Nullable<int> SalIntrmd_Si { get; set; }
        public Nullable<int> SalBrnch_Si { get; set; }
        public bool ChangeSelfPassword { get; set; }
        public string phone { get; set; }
        public string fullName { get; set; }
        public string WebPassword { get; set; }
        public string CuAcc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ownerInvoice> ownerInvoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ownerStorage> ownerStorages { get; set; }
        public virtual UserPermision UserPermision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToInvInvt> userToInvInvts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToSalBrnch> userToSalBrnches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToSalIntrmd> userToSalIntrmds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToSalResp> userToSalResps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToSalTyp> userToSalTyps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userToSalvariety> userToSalvarieties { get; set; }
    }
}