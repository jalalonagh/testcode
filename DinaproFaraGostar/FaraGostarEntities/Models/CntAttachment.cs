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
    
    public partial class CntAttachment
    {
        public int CntAttachment_Si { get; set; }
        public int CntContract_Si { get; set; }
        public string CntAttachment_Tx { get; set; }
        public byte[] CntAttachment_File { get; set; }
        public string CntAttachment_FileName { get; set; }
        public Nullable<int> CntAttachment_FileSize { get; set; }
        public string CntAttachment_FileType { get; set; }
        public Nullable<int> CntAttachTyp_Si { get; set; }
    
        public virtual CntAttachTyp CntAttachTyp { get; set; }
        public virtual CntContract CntContract { get; set; }
    }
}