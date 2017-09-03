using System.Net.Http;
using System.Threading.Tasks;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<PublicRoomsResponse> GetPublicRoomsAsync() =>
            MakeRequestAsync<PublicRoomsResponse>("r0/publicRooms", HttpMethod.Get);
    }
}
