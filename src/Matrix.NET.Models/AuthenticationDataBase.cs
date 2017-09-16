using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Matrix.NET.Models
{
    public abstract class AuthenticationDataBase
    {
        /// <summary>
        /// Required. The login type that the client is attempting to complete.
        /// </summary>
        [Required]
        [JsonRequired]
        public AuthenticationType Type { get; set; }

        /// <summary>
        /// The value of the session key given by the homeserver.
        /// </summary>
        public string Session { get; set; }
    }

    public class DummyAuthenticationData : AuthenticationDataBase
    {

    }

    public class PasswordBasedAuthenticationData : AuthenticationDataBase
    {
        public string User { get; set; }

        public string Password { get; set; }
    }

    public class ThirdPartyAuthenticationData : AuthenticationDataBase
    {
        public string Medium { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
    }
}
