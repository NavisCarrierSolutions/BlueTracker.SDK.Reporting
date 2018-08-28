using System;
using System.Collections.Generic;
using Bluetracker.SDK.Reporting.Enums;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class PortCallDetails
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("ship")]
        public Ship Ship { get; set; }

        [JsonProperty("customId")]
        public int CustomId { get; set; }

        [JsonProperty("eta")]
        public DateTimeOffset? Eta { get; set; }

        [JsonProperty("etb")]
        public DateTimeOffset? Etb { get; set; }

        [JsonProperty("etd")]
        public DateTimeOffset? Etd { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("inboundVoyage")]
        public Voyage InboundVoyage { get; set; }

        [JsonProperty("outboundVoyage")]
        public Voyage OutboundVoyage { get; set; }

        [JsonProperty("portActivities")]
        public List<PortActivity> PortActivities { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
