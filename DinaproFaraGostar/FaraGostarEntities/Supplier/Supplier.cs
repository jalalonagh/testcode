using Newtonsoft.Json;

namespace FaraGostarEntities.Supplier
{
    /// <summary>
    /// origin table name is : PurVndr
    /// </summary>
    public class Supplier
    {
        [JsonProperty("PurVndr_Si")]
        public int Id { get; set; }
        [JsonProperty("PurVndr_Cu")]
        public string Code { get; set; }
        [JsonProperty("PurVndr_Tp")]
        public string Title { get; set; }
        [JsonProperty("PurVndr_Docno")]
        public string DocumentNo { get; set; }
        [JsonProperty("PurVndr_Score")]
        public int? Score { get; set; }
        [JsonProperty("PurVndr_Kind")]
        public byte? PurVndr_Kind { get; set; }
        [JsonProperty("PurVndr_Sts")]
        public byte? PurVndr_Sts { get; set; }
        [JsonProperty("PurVndr_Comment")]
        public string Comment { get; set; }
        [JsonProperty("PurVndrGrp_Si")]
        public int? SupplierGroupId { get; set; }
        [JsonProperty("AccM_Si_1")]
        public int? AccM_Si_1 { get; set; }
        [JsonProperty("AccT_Si")]
        public int? AccT_Si { get; set; }
        [JsonProperty("PurVndr_CorporateTyp")]
        public short? PurVndr_CorporateTyp { get; set; }
        [JsonProperty("CtbCustVndrTyp_Si")]
        public short? CtbCustVndrTyp_Si { get; set; }
        [JsonProperty("AccLC_Si")]
        public int? AccLC_Si { get; set; }
        [JsonProperty("AccLP_Si")]
        public int? AccLP_Si { get; set; }
        //public virtual ICollection<AstAsset> AstAssets { get; set; }
        //public virtual CtbAccM CtbAccM { get; set; }
        //public virtual CtbAccT CtbAccT { get; set; }
        //public virtual ICollection<InvDocH> InvDocHes { get; set; }
        //public virtual ICollection<PurEnqry> PurEnqries { get; set; }
        //public virtual ICollection<PurInvcH> PurInvcHes { get; set; }
        //public virtual ICollection<PurOrdr> PurOrdrs { get; set; }
        //public virtual PurVndrGrp PurVndrGrp { get; set; }
    }
}
