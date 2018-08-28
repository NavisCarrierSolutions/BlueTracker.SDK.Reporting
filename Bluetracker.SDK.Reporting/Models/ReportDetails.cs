using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    /// <summary>
    /// Details of a report including report data.
    /// </summary>
    [Serializable]
    public class ReportDetails
    {
        /// <summary>
        /// Unique identifier of call
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Description of reporting event
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Event date and time inclduing time zone
        /// </summary>
        [JsonProperty("eventTime")]
        public DateTimeOffset EventTime { get; set; }

        /// <summary>
        /// Original port
        /// </summary>
        [JsonProperty("originalPort")]
        public Location OriginalPort { get; set; }

        /// <summary>
        /// Destination port
        /// </summary>
        [JsonProperty("destinationPort")]
        public Location DestinationPort { get; set; }

        /// <summary>
        /// Voyage associated to report
        /// </summary>
        [JsonProperty("voyage")]
        public Voyage Voyage { get; set; }

        /// <summary>
        /// Timestamp of report creation (last revision)
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Name of user who created last report revision
        /// </summary>
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Data inlcuded in report
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}
