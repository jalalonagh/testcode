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
    
    public partial class PrdcBOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrdcBOM()
        {
            this.PrdcBOMDs = new HashSet<PrdcBOMD>();
            this.PrdcLineTitles = new HashSet<PrdcLineTitle>();
            this.PrdcTraceDInfoes = new HashSet<PrdcTraceDInfo>();
            this.PrdcWorkOrderDInfoes = new HashSet<PrdcWorkOrderDInfo>();
        }
    
        public int PrdcBOM_Si { get; set; }
        public Nullable<int> InvGds_Si { get; set; }
        public string PrdcBOM_Formula { get; set; }
        public Nullable<bool> PrdcBOM_IsAlternative { get; set; }
        public string PrdcBOM_Description { get; set; }
        public Nullable<bool> PrdcBOM_Active { get; set; }
        public Nullable<double> PrdcBOM_Quantity { get; set; }
        public string PrdcBOM_DefineDate { get; set; }
        public byte[] PrdcBOM_File { get; set; }
        public string PrdcBOM_FileName { get; set; }
        public Nullable<bool> PrdcBOM_ChangeInWorkOrder { get; set; }
    
        public virtual InvGd InvGd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdcBOMD> PrdcBOMDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdcLineTitle> PrdcLineTitles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdcTraceDInfo> PrdcTraceDInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrdcWorkOrderDInfo> PrdcWorkOrderDInfoes { get; set; }
    }
}
