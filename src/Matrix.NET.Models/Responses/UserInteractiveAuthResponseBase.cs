using Matrix.NET.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Matrix.NET.Models.Responses
{
    public abstract class UserInteractiveAuthResponseBase : IResponse
    {
    }

    /// <summary>
    /// This section contains any information that the client will need to know in order to use a given type of authentication. For each authentication type presented, that type may be present as a key in this dictionary. For example, the public part of an OAuth client ID could be given here.
    /// </summary>
    public class UserInteractiveAuthParameters
    {
        [JsonProperty(Constants.Authentication.Types.PasswordBased)]
        public JObject PasswordBased { get; set; }

        [JsonProperty(Constants.Authentication.Types.GoogleReCaptcha)]
        public JObject GoogleReCaptcha { get; set; }

        [JsonProperty(Constants.Authentication.Types.TokenBased)]
        public JObject TokenBased { get; set; }

        [JsonProperty(Constants.Authentication.Types.OAuth2Based)]
        public JObject OAuth2Based { get; set; }

        [JsonProperty(Constants.Authentication.Types.EmailBased)]
        public JObject EmailBased { get; set; }

        [JsonProperty(Constants.Authentication.Types.Dummy)]
        public JObject Dummy { get; set; }
    }

    public class UserInteractiveAuthFlow
    {
        public string[] Stages { get; set; }
    }

    public class UserInteractiveAuthResponse : UserInteractiveAuthResponseBase
    {
        public string Session { get; set; }

        public UserInteractiveAuthParameters Params { get; set; }

        public UserInteractiveAuthFlow[] Flows { get; set; }
    }
}
