using System.Net.Http;
using System.Threading.Tasks;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Matrix.NET.Models.Responses;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        public Task<LoginResponse> LoginAsync(LoginRequest request) =>
            MakeRequestAsync(request);

        public Task LogoutAsync() =>
            MakeRequestAsync(new ParameterlessRequest<EmptyResponse>(
                "client/{version}/logout?access_token={accessToken}", HttpMethod.Post, true));

        public Task<UserInteractiveAuthResponseBase> RegisterAsync<TAuth>(RegisterRequest<TAuth> request)
            where TAuth : AuthenticationDataBase =>
            MakeRequestAsync(request, false, typeof(UserInteractiveAuthResponse), typeof(RegisterResponse));
    }
}