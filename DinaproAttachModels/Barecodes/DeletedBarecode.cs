using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DinaproAttachModels.Barecodes
{
    /// <summary>
    /// origin table name is : DeletedSerialInvgd
    /// </summary>
    public class DeletedBarecode
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("invgds_cu")]
        public string ProductCode { get; set; }
        [JsonProperty("invgds_Serial")]
        public string ProductBarecode { get; set; }
        [JsonProperty("timeDeleted")]
        public System.DateTime DeletedTime { get; set; }
        [JsonProperty("requestedDoc_Code")]
        public int? RequestDocumentCode { get; set; }
        [JsonProperty("timeSet")]
        public DateTime? IssuedTime { get; set; }
        [JsonProperty("invdoctyp_si")]
        public int? InvoiceDocumentTypeId { get; set; }
        [JsonProperty("invdoch_cu")]
        public int? InvoiceDocumentHeaderCode { get; set; }
        [JsonProperty("invinvt_cu")]
        public string StoreCode { get; set; }
        [JsonProperty("userDeleted")]
        public string UserDeleted { get; set; }
        [JsonProperty("userInvinvt_cu")]
        public string StoreUserId { get; set; }
        [JsonProperty("userInvdoctyp_si")]
        public int? UserInvdoctypSI { get; set; }
        [JsonProperty("userInvdoch_cu")]
        public int? UserInvdochCU { get; set; }
        [JsonProperty("userRequestedDoc_Code")]
        public int? UserRequestedDocCode { get; set; }
    }
}
