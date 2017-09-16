using Matrix.NET.Models;
using Newtonsoft.Json;

namespace Matrix.NET.Client.Responses
{
    public class VersionsResponse : IResponse
    {
        [JsonProperty(Required = Required.Always)]
        public string[] Versions { get; set; }
    }
}
