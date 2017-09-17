using System.Net.Http;
using Matrix.NET.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Matrix.NET.Models.Requests
{
    public class RegisterRequest<TAuth> : RequestBase<UserInteractiveAuthResponseBase>
        where TAuth : AuthenticationDataBase
    {
        /// <summary>
        /// The kind of account to register. Defaults to user. One of: ["guest", "user"]
        /// </summary>
        /// <remarks>
        /// Query parameter
        /// </remarks>
        [JsonIgnore]
        public UserAccountKind Kind { get; } = UserAccountKind.User;

        /// <summary>
        /// Additional authentication information for the user-interactive authentication API. Note that
        /// this information is not used to define how the registered user should be authenticated, but
        /// is instead used to authenticate the register call itself.It should be left empty, or omitted,
        /// unless an earlier call returned an response with status code 401.
        /// </summary>
        public TAuth Auth { get; set; }

        /// <summary>
        /// If true, the server binds the email used for authentication to the Matrix ID with the ID Server.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public bool BindEmail { get; set; }

        /// <summary>
        /// The local part of the desired Matrix ID.If omitted, the homeserver MUST generate a Matrix ID local part.
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The desired password for the account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ID of the client device. If this does not correspond to a known client device, a new device will
        /// be created.The server will auto-generate a device_id if this is not specified.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string DeviceId { get; set; }

        /// <summary>
        /// A display name to assign to the newly-created device. Ignored if device_id corresponds to a known
        /// device.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string InitialDeviceDisplayName { get; set; }

        public RegisterRequest()
            : base("client/{version}/register", HttpMethod.Post, false)
        {
        }

        public RegisterRequest(UserAccountKind accountKind)
            : base("client/{version}/register?kind={kind}", HttpMethod.Post, false)
        {
            Kind = accountKind;
            PathParameters.Add("kind", JsonConvert.SerializeObject(Kind, new StringEnumConverter(true)));
        }
    }
}
