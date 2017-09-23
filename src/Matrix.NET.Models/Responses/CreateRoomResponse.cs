using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Responses
{
    public class CreateRoomResponse : ResponseBase
    {
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string RoomId { get; set; }
    }
}
