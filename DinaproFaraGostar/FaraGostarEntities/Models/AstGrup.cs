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
    
    public partial class AstGrup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AstGrup()
        {
            this.AstAssets = new HashSet<AstAsset>();
        }
    
        public string AstGrup_Id { get; set; }
        public string AstGrup_Tx { get; set; }
        public byte AstCnsMthd_Id { get; set; }
        public Nullable<double> AstGrup_DepreciateRate { get; set; }
        public string AccAcnt_Id_Depreciate { get; set; }
        public string AccAcnt_Id_ADepreciate { get; set; }
        public Nullable<int> AccM_Si_1 { get; set; }
        public Nullable<int> AccT_Si_1 { get; set; }
        public Nullable<int> AccM_Si { get; set; }
        public Nullable<int> AccT_Si { get; set; }
        public Nullable<int> AstGrup_IdParent { get; set; }
        public Nullable<int> AccM_Si_2 { get; set; }
        public Nullable<int> AccT_Si_2 { get; set; }
        public Nullable<int> AccLC_Si { get; set; }
        public Nullable<int> AccLP_Si { get; set; }
        public Nullable<int> AccLC_Si_1 { get; set; }
        public Nullable<int> AccLP_Si_1 { get; set; }
        public Nullable<int> AccLC_Si_2 { get; set; }
        public Nullable<int> AccLP_Si_2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AstAsset> AstAssets { get; set; }
        public virtual AstCnsMthd AstCnsMthd { get; set; }
    }
}