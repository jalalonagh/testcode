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
    
    public partial class AccBudgetPeriodLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccBudgetPeriodLevel()
        {
            this.AccBudgetLogs = new HashSet<AccBudgetLog>();
            this.AccBudgetPeriods = new HashSet<AccBudgetPeriod>();
        }
    
        public int AccBudgetPeriodLevel_Si { get; set; }
        public string AccBudgetPeriodLevel_Cu { get; set; }
        public string AccBudgetPeriodLevel_Name { get; set; }
        public Nullable<bool> AccBudgetPeriodLevel_IsActive { get; set; }
        public Nullable<bool> AccBudgetPeriodLevel_IsRevisionBase { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccBudgetLog> AccBudgetLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccBudgetPeriod> AccBudgetPeriods { get; set; }
    }
}
