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
    
    public partial class Setting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Setting()
        {
            this.CompanyTelegrams = new HashSet<CompanyTelegram>();
        }
    
        public int id { get; set; }
        public System.TimeSpan SendSMSInvoices { get; set; }
        public System.TimeSpan SendTelegramInvoices { get; set; }
        public string TelegramHash { get; set; }
        public string TelegramCode { get; set; }
        public Nullable<int> LastCodeInvoice { get; set; }
        public Nullable<bool> SendSmsIsActive { get; set; }
        public Nullable<int> lastCodeInvoiceInverse { get; set; }
        public string TelegramCodeAutoSMS { get; set; }
        public string TelegramHashAutoSMS { get; set; }
        public Nullable<bool> TelegramAutoRegister { get; set; }
        public Nullable<bool> SendMessageSchedule { get; set; }
        public string startDinaCard { get; set; }
        public string lastVersionClient { get; set; }
        public string lastDinaPro { get; set; }
        public Nullable<bool> isActiveZeroQtyInRandomStorage { get; set; }
        public Nullable<bool> isAdminDemand { get; set; }
        public Nullable<bool> isAllow102030 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyTelegram> CompanyTelegrams { get; set; }
    }
}