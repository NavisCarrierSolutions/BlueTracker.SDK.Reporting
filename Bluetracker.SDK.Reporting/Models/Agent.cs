using Bluetracker.SDK.Reporting.Enums;
using Newtonsoft.Json;

namespace Bluetracker.SDK.Reporting.Models
{
    public class Agent
    {
        [JsonProperty("agentType")]
        public AgentType AgentType { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }
    }
}