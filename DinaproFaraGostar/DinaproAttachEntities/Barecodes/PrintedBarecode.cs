using Newtonsoft.Json;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origin table name is : BarcodeIsPrinted
    /// </summary>
    public class PrintedBarecode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("invgds_cu")]
        public string ProductCode { get; set; }
        [JsonProperty("invinvt_cu")]
        public string StoreCode { get; set; }
    }
}
