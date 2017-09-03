using Matrix.Client.Types;
using Newtonsoft.Json;

namespace Matrix.Client.Requests
{
    public sealed class LoginRequest
    {
        public string Address { get; set; }

        public string Medium { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; } = LoginType.Password;

        public string User { get; set; }

        public LoginRequest(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
