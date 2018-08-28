using System;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class Location
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("unloc")]
        public string Unloc { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
