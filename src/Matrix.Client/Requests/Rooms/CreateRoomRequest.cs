using System.Collections.Generic;
using System.Net.Http;
using Matrix.Client.Responses;
using Matrix.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Matrix.Client.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CreateRoomRequest : RequestBase<EmptyResponse>
    {
        [JsonProperty]
        public string Visiblity { get; set; } // ToDo enum

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string RoomAliasName { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Topic { get; set; }

        [JsonProperty]
        public IEnumerable<string> Invite { get; set; }

        [JsonProperty("invite_3pid")]
        public IEnumerable<object> Invite3Pid { get; set; } // ToDo

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public object CreationContent { get; set; } // ToDo

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public object InitialState { get; set; } // ToDo

        [JsonProperty]
        public string Preset { get; set; } // ToDo

        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public bool? IsDirect { get; set; }

        public CreateRoomRequest()
            : base("client/r0/createRoom", HttpMethod.Post, true)
        {
        }
    }
}
