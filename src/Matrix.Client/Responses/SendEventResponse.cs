using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.Client.Responses
{
    public class SendEventResponse : IResponse
    {
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public string EventId { get; set; }
    }
}
