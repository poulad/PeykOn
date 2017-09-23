using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Types
{
    public class StateEvent
    {
        public string Type { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string StateKey { get; set; }

        public string Content { get; set; }
    }
}