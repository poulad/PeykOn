using Matrix.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Client.Responses
{
    public class SendEventResponse : IResponse
    {
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public string EventId { get; set; }
    }
}
