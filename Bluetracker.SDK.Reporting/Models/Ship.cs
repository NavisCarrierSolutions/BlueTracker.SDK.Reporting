using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bluetracker.SDK.Reporting.Models
{
    /// <summary>
    /// A ship.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Unique identifier of the ship.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; internal set; }

        /// <summary>
        /// Name of ship.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// 7-digit IMO-number of the ship.
        /// </summary>
        [JsonProperty("imoNumber")]
        public int ImoNumber { get; internal set; }

        /// <summary>
        /// only for use with Json transfer.
        /// </summary>
        [JsonProperty("lastTransferPackageReceivedOn")]
        public DateTimeOffset LastTransferPackageReceivedOn { get; set; }
    }
}