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
    
    public partial class SalDepend
    {
        public int SalDepend_Si { get; set; }
        public string SalDepend_Tp { get; set; }
        public string SalDepend_Job { get; set; }
        public string SalDepend_Email { get; set; }
        public string SalDepend_Mobile { get; set; }
        public string SalDepend_Tel { get; set; }
        public Nullable<bool> SalDepend_IsMain { get; set; }
        public string SalDepend_Desc { get; set; }
        public Nullable<int> SalCust_Si { get; set; }
        public string SalDepend_SpecialDayDesc { get; set; }
        public string SalDepend_SpecialDayDate { get; set; }
        public string SalDepend_Birthdate { get; set; }
        public Nullable<bool> SalDepend_IsVip { get; set; }
        public Nullable<bool> SalDepend_Active { get; set; }
        public string SalDepend_Email2 { get; set; }
    
        public virtual SalCust SalCust { get; set; }
    }
}