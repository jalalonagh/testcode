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
    
    public partial class AstAssetDprc
    {
        public string AstAsset_Id { get; set; }
        public System.DateTime AstAssetDprc_Date { get; set; }
        public decimal AstAssetDprc_Price { get; set; }
        public Nullable<int> AstVchr_Id { get; set; }
    
        public virtual AstAsset AstAsset { get; set; }
    }
}
