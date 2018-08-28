using System;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    /// <summary>
    /// Summary of report.
    /// </summary>
    [Serializable]
    public class Report
    {
        /// <summary>
        /// Unique identifier of report
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Description of reporting event
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Number of voyage associated to report
        /// </summary>
        [JsonProperty("voyageNo")]
        public string VoyageNo { get; set; }

        /// <summary>
        /// Original port UN/LOCODE
        /// </summary>
        [JsonProperty("originalPort")]
        public string OriginalPort { get; set; }

        /// <summary>
        /// Destination port UN/LOCODE
        /// </summary>
        [JsonProperty("destinationPort")]
        public string DestinationPort { get; set; }

        /// <summary>
        /// Event date and time inclduing time zone
        /// </summary>
        [JsonProperty("eventTime")]
        public DateTimeOffset EventTime { get; set; }

        /// <summary>
        /// Timestamp of report creation (last revision)
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Name of user who created last report revision
        /// </summary>
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
    }
}
