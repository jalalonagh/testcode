//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DinaproAttachModels.Models
{
    using System;
    using System.Collections.Generic;
    
    public class RequestPrintLabel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestPrintLabel()
        {
            //this.SerialsInRequesteds = new HashSet<SerialsInRequested>();
        }
    
        public int id { get; set; }
        public string creator_User { get; set; }
        public Nullable<int> invdoch_cu { get; set; }
        public Nullable<int> invdoctyp_si { get; set; }
        public string invgds_cu { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<int> Doc_Code { get; set; }
        public Nullable<System.DateTime> date_Dm { get; set; }
        public string date_Ds { get; set; }
        public string invinvt_cu { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> created_Dm { get; set; }
        public Nullable<bool> isAll { get; set; }
        public Nullable<bool> isConfirm { get; set; }
        public string confirmByUserName { get; set; }
        public Nullable<System.DateTime> confirmDate_Dm { get; set; }
        public string confirmDate_Ds { get; set; }
        public Nullable<bool> isPrint { get; set; }
        public string adminDescription { get; set; }
        public Nullable<bool> DeleteBarcodeNotInputed { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SerialsInRequested> SerialsInRequesteds { get; set; }
    }
}