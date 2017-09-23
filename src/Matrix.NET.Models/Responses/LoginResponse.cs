using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Responses
{
    public class LoginResponse : ResponseBase
    {
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string AccessToken { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string HomeServer { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string RefreshToken { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string UserId { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string DeviceId { get; set; }
    }
}