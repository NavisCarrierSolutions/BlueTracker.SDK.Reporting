using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class Voyage
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("customID")]
        public int CustomId { get; set; }

        [JsonProperty("voyageNo")]
        public string VoyageNo { get; set; }
    }
}
