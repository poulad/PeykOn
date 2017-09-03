using System.Net.Http;
using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<Login> LoginAsync(LoginRequest request) =>
            MakeRequestAsync<Login>("r0/login", HttpMethod.Post, data: request);

        public Task LogoutAsync() =>
            MakeRequestAsync<object>("r0/logout", HttpMethod.Post, true);
    }
}
