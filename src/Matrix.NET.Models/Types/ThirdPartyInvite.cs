using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Types
{
    public class ThirdPartyInvite
    {
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string IdServer { get; set; }

        public string Medium { get; set; } // ToDo: use enum maybe

        public string Address { get; set; }
    }
}