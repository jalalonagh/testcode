using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origin table name is : BarecodeManual
    /// </summary>
    public class ManualBarcode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("invgds_cu")]
        public string ProductCode { get; set; }
        [JsonProperty("storage_cu")]
        public string StoreCode { get; set; }
    }
}
