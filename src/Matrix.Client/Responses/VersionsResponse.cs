using Newtonsoft.Json;

namespace Matrix.Client.Responses
{
    public class VersionsResponse : IResponse
    {
        [JsonProperty(Required = Required.Always)]
        public string[] Versions { get; set; }
    }
}
