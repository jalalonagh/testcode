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
    
    public partial class AssMachinId
    {
        public int AssMachinId_Si { get; set; }
        public Nullable<System.DateTime> AssMachinId_SetupDate { get; set; }
        public Nullable<System.DateTime> AssMachinId_GaranteeDate_S { get; set; }
        public Nullable<System.DateTime> AssMachinId_GaranteeDate_E { get; set; }
        public string AssMachinId_Note { get; set; }
        public Nullable<int> AssMachine_Si { get; set; }
        public Nullable<int> AssMachineModel_Si { get; set; }
        public Nullable<int> AssCust_Si { get; set; }
        public Nullable<System.DateTime> AssMachinId_SaleDate { get; set; }
        public string AssMachine_Serial { get; set; }
    
        public virtual AssCust AssCust { get; set; }
        public virtual AssMachine AssMachine { get; set; }
        public virtual AssMachineModel AssMachineModel { get; set; }
    }
}
