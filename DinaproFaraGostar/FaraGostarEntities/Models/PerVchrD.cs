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
    
    public partial class PerVchrD
    {
        public int PerVchrD_Id { get; set; }
        public int PerVchrH_Id { get; set; }
        public Nullable<int> AccLM_Si { get; set; }
        public Nullable<int> AccLT_Si { get; set; }
        public Nullable<int> AccLC_Si { get; set; }
        public Nullable<int> AccLP_Si { get; set; }
        public string PerVchrD_Tx { get; set; }
        public decimal PerVchrD_Debit { get; set; }
        public decimal PerVchrD_Credit { get; set; }
        public string PerVchrD_Date { get; set; }
        public Nullable<int> PerVchrH_Row { get; set; }
        public Nullable<decimal> PerVchrD_DebitC { get; set; }
        public Nullable<decimal> PerVchrD_CreditC { get; set; }
        public Nullable<int> CtbCurncy_Si { get; set; }
        public Nullable<double> ExchangeRate { get; set; }
        public string PerOpr_Cu { get; set; }
    
        public virtual CtbAccM CtbAccM { get; set; }
        public virtual CtbAccT CtbAccT { get; set; }
        public virtual CtbCost CtbCost { get; set; }
        public virtual CtbProject CtbProject { get; set; }
        public virtual PerVchrH PerVchrH { get; set; }
    }
}
