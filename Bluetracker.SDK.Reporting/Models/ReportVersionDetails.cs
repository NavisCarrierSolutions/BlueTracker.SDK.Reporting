using System;
using System.Collections.Generic;
using Bluetracker.SDK.Reporting.Enums;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class ReportVersionDetails
    {
        /// <summary>
        /// Unique identifier of report version
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

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

        /// <summary>
        /// Current workflow status of report version
        /// </summary>
        [JsonProperty("reportState")]
        public ReportStateOptions ReportState { get; set; }

        /// <summary>
        /// Status of report validation
        /// </summary>
        [JsonProperty("validationState")]
        public ValidationStateOptions ValidationState { get; set; }

        /// <summary>
        /// Data inlcuded in report
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}