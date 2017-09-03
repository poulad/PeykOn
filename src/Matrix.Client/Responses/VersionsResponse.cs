using Newtonsoft.Json;

namespace Matrix.Client.Responses
{
    public class VersionsResponse
    {
        [JsonProperty(Required = Required.Always)]
        public string[] Versions { get; set; }
    }
}
