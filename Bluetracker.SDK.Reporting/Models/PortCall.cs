using System;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class PortCall
    {
        /// <summary>
        /// Unique identifier of call
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid{ get; set; }

        /// <summary>
        /// Custom ID of call (optional)
        /// </summary>
        [JsonProperty("customId")]
        public int CustomId { get; set; }

        /// <summary>
        /// Estimated time of arrival
        /// </summary>
        [JsonProperty("eta")]
        public DateTimeOffset? Eta { get; set; }

        /// <summary>
        /// Estimated time of berth
        /// </summary>
        [JsonProperty("etb")]
        public DateTimeOffset? Etb { get; set; }

        /// <summary>
        /// Estimated time of departure
        /// </summary>
        [JsonProperty("etd")]
        public DateTimeOffset? Etd { get; set; }

        /// <summary>
        /// UN/LOCODE of location.
        /// </summary>
        [JsonProperty("locationUnloc")]
        public string LocationUnloc { get; set; }

        /// <summary>
        /// Name port location.
        /// </summary>
        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        /// <summary>
        /// Inbound voyage number
        /// </summary>
        [JsonProperty("inboundVoyageNumber")]
        public string InboundVoyageNumber { get; set; }

        /// <summary>
        /// Outbound voyage number
        /// </summary>
        [JsonProperty("outboundVoyageNumber")]
        public string OutboundVoyageNumber { get; set; }

        /// <summary>
        /// Timestamp when PortCall has been changed last time by import from ship
        /// </summary>
        [JsonProperty("lastChangeOnImport")]
        public DateTimeOffset? LastChangeOnImport { get; set; }

        /// <summary>
        /// This PortCall is omitted (true) or not (false)
        /// </summary>
        [JsonProperty("isOmitted")]
        public bool IsOmitted { get; set; }

        /// <summary>
        /// Delete Flag: True = PortCall is deleted
        /// </summary>
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
