using System.Net.Http;
using System.Threading.Tasks;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Responses;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        public Task<Login> LoginAsync(LoginRequest request) =>
            MakeRequestAsync(request);

        public Task LogoutAsync() =>
            MakeRequestAsync(new ParameterlessRequest<EmptyResponse>(
                "client/{version}/logout?access_token={accessToken}", HttpMethod.Post, true));

        public Task<UserInteractiveAuthResponseBase> RegisterAsync(RegisterRequest request) =>
            MakeRequestAsync(request, false, typeof(UserInteractiveAuthResponse), typeof(RegisterResponse));
    }
}
