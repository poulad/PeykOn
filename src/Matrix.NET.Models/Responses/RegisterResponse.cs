using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Responses
{
    public class RegisterResponse : UserInteractiveAuthResponseBase
    {
        /// <summary>
        /// The fully-qualified Matrix ID that has been registered.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string UserId { get; set; }

        /// <summary>
        /// An access token for the account.This access token can then be used to authorize other requests.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string AccessToken { get; set; }

        /// <summary>
        /// The hostname of the homeserver on which the account has been registered.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string HomeServer { get; set; }

        /// <summary>
        // ID of the registered device.Will be the same as the corresponding parameter in the request, if one was specified.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string DeviceId { get; set; }
    }
}
