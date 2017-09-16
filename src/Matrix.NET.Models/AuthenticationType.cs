using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Matrix.NET.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthenticationType
    {
        /// <summary>
        /// The client submits a username and secret password, both sent in plain-text.
        /// </summary>
        /// <remarks>
        /// To use this authentication type, clients should submit an auth dict of type <see cref="PasswordBasedAuthenticationData"/> or <see cref="ThirdPartyAuthenticationData"/>
        /// </remarks>
        [EnumMember(Value = Constants.Authentication.Types.PasswordBased)]
        PasswordBased,

        [EnumMember(Value = Constants.Authentication.Types.GoogleReCaptcha)]
        GoogleReCaptcha,

        [EnumMember(Value = Constants.Authentication.Types.TokenBased)]
        TokenBased,

        [EnumMember(Value = Constants.Authentication.Types.OAuth2Based)]
        OAuth2Based,

        [EnumMember(Value = Constants.Authentication.Types.EmailBased)]
        EmailBased,

        [EnumMember(Value = Constants.Authentication.Types.Dummy)]
        Dummy,
    }
}
