using Newtonsoft.Json;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origin table name is : RepeatSerial
    /// </summary>
    public class RepeatableBarecode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("serialInvgd")]
        public string Barecode { get; set; }
        [JsonProperty("invgd_cu")]
        public string ProductCode { get; set; }
    }
}
