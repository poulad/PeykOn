using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Client.Types
{
    public class PublicRoomsChunk
    {
        public string[] Aliases { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string CanonicalAlias { get; set; }

        public string Name { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public int NumJoinedMembers { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public string RoomId { get; set; }

        public string Topic { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public bool WorldReadable { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy), Required = Required.Always)]
        public bool GuestCanJoin { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string AvatarUrl { get; set; }
    }
}
