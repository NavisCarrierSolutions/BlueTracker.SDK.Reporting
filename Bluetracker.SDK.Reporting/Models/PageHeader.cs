using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class PageHeader
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("items")]
        public List<Report> Items { get; set; }
    }
}
