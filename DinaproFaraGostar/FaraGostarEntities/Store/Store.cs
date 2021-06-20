using Newtonsoft.Json;
namespace FaraGostarEntities.Store
{
    /// <summary>
    /// origin table name is : InvInvt
    /// </summary>
    public class Store
    {
        [JsonProperty("InvInvt_Si")]
        public int Id { get; set; }
        [JsonProperty("InvInvt_Cu")]
        public string Code { get; set; }
        [JsonProperty("InvInvt_Tp")]
        public string Title { get; set; }
        [JsonProperty("InvInvt_Address")]
        public string Address { get; set; }
        [JsonProperty("InvInvt_SiParent")]
        public int Parent { get; set; }
        [JsonProperty("AccLM_Si")]
        public int? AccLM_Si { get; set; }
        [JsonProperty("AccLT_Si")]
        public int? AccLT_Si { get; set; }
        [JsonProperty("InvInvtType_Si")]
        public short? TypeId { get; set; }
        [JsonProperty("AccLC_Si")]
        public int? AccLC_Si { get; set; }
        [JsonProperty("AccLP_Si")]
        public int? AccLP_Si { get; set; }
        [JsonProperty("InvInvt_IsActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("InvInvt_IsActiveSale")]
        public bool? IsActiveToSale { get; set; }
        [JsonProperty("InvInvt_isActiveInDclprc")]
        public bool? InvInvt_isActiveInDclprc { get; set; }
        //public virtual CtbAccT CtbAccT { get; set; }
        //public virtual CtbCost CtbCost { get; set; }
        //public virtual CtbProject CtbProject { get; set; }
        //public virtual ICollection<InvBatchNumber> InvBatchNumbers { get; set; }
        //public virtual ICollection<InvCntH> InvCntHs { get; set; }
        //public virtual ICollection<InvDocAuto> InvDocAutoes { get; set; }
        //public virtual ICollection<InvDocAuto> InvDocAutoes1 { get; set; }
        //public virtual ICollection<InvDocH> InvDocHes { get; set; }
        //public virtual ICollection<InvGdsToGd> InvGdsToGds { get; set; }
        //public virtual ICollection<InvGdsToInv> InvGdsToInvs { get; set; }
        //public virtual ICollection<InvVchrH> InvVchrHs { get; set; }
        //public virtual ICollection<PrdcTraceH> PrdcTraceHs { get; set; }
        //public virtual ICollection<PurRqstH> PurRqstHs { get; set; }
        //public virtual ICollection<SalInvcH> SalInvcHes { get; set; }
        //public virtual ICollection<SalRetInvcH> SalRetInvcHes { get; set; }
    }
}
