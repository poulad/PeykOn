using Matrix.Client.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.Client.Responses
{
    public class PublicRoomsResponse
    {
        [JsonProperty(Required = Required.Always)]
        public PublicRoomsChunk[] Chunk { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string NextBatch { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string PrevBatch { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public int? TotalRoomCountEstimate { get; set; }
    }
}
