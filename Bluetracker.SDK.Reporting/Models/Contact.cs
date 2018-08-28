using System;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class Contact
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("personInCharge")]
        public string PersonInCharge { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("email1")]
        public string Email1 { get; set; }

        [JsonProperty("email2")]
        public string Email2 { get; set; }

        [JsonProperty("email3")]
        public string Email3 { get; set; }

        [JsonProperty("phone1")]
        public string Phone1 { get; set; }

        [JsonProperty("phone2")]
        public string Phone2 { get; set; }

        [JsonProperty("phone3")]
        public string Phone3 { get; set; }
    }
}