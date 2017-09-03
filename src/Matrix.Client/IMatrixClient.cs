using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public interface IMatrixClient
    {
        string HomeserverUrl { get; }

        string AccessToken { get; set; }

        Task<string[]> GetVersionsAsync();

        Task<Login> LoginAsync(LoginRequest request);

        Task<PublicRoomsResponse> GetPublicRoomsAsync();

        Task LogoutAsync();
    }
}
