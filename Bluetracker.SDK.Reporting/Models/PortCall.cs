using System;
using System.Globalization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class PortCall
    {
        [JsonProperty("uid")]
        public Guid Uid{ get; set; }

        [JsonProperty("customId")]
        public int CustomId { get; set; }

        [JsonProperty("eta")]
        public DateTimeOffset? Eta { get; set; }

        [JsonProperty("etb")]
        public DateTimeOffset? Etb { get; set; }

        [JsonProperty("etd")]
        public DateTimeOffset? Etd { get; set; }

        [JsonProperty("locationUnloc")]
        public string LocationUnloc { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("inboundVoyageNumber")]
        public string InboundVoyageNumber { get; set; }

        [JsonProperty("outboundVoyageNumber")]
        public string OutboundVoyageNumber { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
