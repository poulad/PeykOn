using Matrix.Client.Types;
using Matrix.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.Client.Responses
{
    public class PublicRoomsResponse : IResponse
    {
        [JsonProperty(Required = Required.Always)]
        public PublicRoomsChunk[] Chunk { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string NextBatch { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string PrevBatch { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public int? TotalRoomCountEstimate { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string NewRooms { get; set; } // ToDo: https://github.com/matrix-org/synapse/issues/2445
    }
}
