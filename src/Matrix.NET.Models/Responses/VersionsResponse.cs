using Newtonsoft.Json;

namespace Matrix.NET.Models.Responses
{
    public class VersionsResponse : IResponse
    {
        [JsonProperty(Required = Required.Always)]
        public string[] Versions { get; set; }
    }
}
