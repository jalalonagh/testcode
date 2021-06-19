using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origing table name is : NotPrintInvgds_Serials
    /// </summary>
    public class NotPrintedBarecode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("invgds_cu")]
        public string ProductCode { get; set; }
    }
}
