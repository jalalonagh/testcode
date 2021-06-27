using Newtonsoft.Json;
using System;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origin table name is : Invgds_Serials
    /// </summary>
    public class ProductBarecode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Serial")]
        public string Barecode { get; set; }
        [JsonProperty("invgds_cu")]
        public string ProductCode { get; set; }
        [JsonProperty("used")]
        public bool Used { get; set; }
        [JsonProperty("@out")]
        public bool External { get; set; }
        [JsonProperty("invinvt_cu")]
        public string StoreCode { get; set; }
        [JsonProperty("invdoch_cu")]
        public int? InvoiceHeaderCode { get; set; }
        [JsonProperty("invdoctyp_si")]
        public int? InvoiceDocumentTypeId { get; set; }
        [JsonProperty("timeSet")]
        public DateTime? IssuedTime { get; set; }
        [JsonProperty("requestedDoc_Code")]
        public int? RequestDocumentCode { get; set; }
        [JsonProperty("Ordination")]
        public bool? Ordination { get; set; }
        [JsonProperty("invgds_cu2")]
        public string AnotherProductCode { get; set; }
    }
}
