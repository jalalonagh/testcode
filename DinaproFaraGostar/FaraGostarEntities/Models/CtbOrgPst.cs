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
    
    public partial class CtbOrgPst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CtbOrgPst()
        {
            this.PerCmds = new HashSet<PerCmd>();
        }
    
        public int CtbOrgPst_Si { get; set; }
        public string CtbOrgPst_Cu { get; set; }
        public string CtbOrgPst_Tp { get; set; }
        public int CtbOrgPst_SiParent { get; set; }
        public int CtbOrgJob_Si { get; set; }
        public int CtbOrgDep_Si { get; set; }
        public Nullable<short> CtbOrgPst_Prmt { get; set; }
        public Nullable<short> CtbOrgPst_Asgn { get; set; }
    
        public virtual CtbOrgDep CtbOrgDep { get; set; }
        public virtual CtbOrgJob CtbOrgJob { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerCmd> PerCmds { get; set; }
    }
}
