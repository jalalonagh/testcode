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
    
    public partial class FaraMnu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaraMnu()
        {
            this.FaraMnuToUsrs = new HashSet<FaraMnuToUsr>();
        }
    
        public int FaraMnu_Si { get; set; }
        public string FaraMnu_Tp { get; set; }
        public int FaraMnu_SiParent { get; set; }
        public Nullable<int> FaraMnu_Sqnc { get; set; }
        public Nullable<int> FaraMnuItm_Si { get; set; }
        public Nullable<bool> FaraMnu_IsShrt { get; set; }
        public byte[] FaraMnu_Icon { get; set; }
        public Nullable<int> FaraMnu_HotKey { get; set; }
        public Nullable<bool> FaraMnu_Autorun { get; set; }
        public Nullable<bool> FaraMnu_HasChild { get; set; }
        public string FaraMnu_License { get; set; }
        public string FaraMnu_Tp_En { get; set; }
        public Nullable<bool> FaraMnu_IsIstandard { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaraMnuToUsr> FaraMnuToUsrs { get; set; }
    }
}