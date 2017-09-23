using System.Collections.Generic;
using System.Net.Http;
using Matrix.NET.Abstractions;
using Matrix.NET.Models.Enums;
using Matrix.NET.Models.Responses;
using Matrix.NET.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Matrix.NET.Models.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CreateRoomRequest : RequestBase<CreateRoomResponse>
    {
        [JsonProperty]
        public RoomVisiblity? Visiblity { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string RoomAliasName { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Topic { get; set; }

        [JsonProperty]
        public IEnumerable<string> Invite { get; set; }

        [JsonProperty("invite_3pid")]
        public IEnumerable<ThirdPartyInvite> Invite3Pid { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public RoomCreationContent CreationContent { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public StateEvent InitialState { get; set; }

        [JsonProperty]
        public RoomPreset? Preset { get; set; }

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public bool? IsDirect { get; set; }

        public CreateRoomRequest()
            : base("client/{version}/createRoom?access_token={accessToken}", HttpMethod.Post, true)
        {
        }
    }
}