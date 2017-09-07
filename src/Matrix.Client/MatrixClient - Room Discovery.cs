using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<PublicRoomsResponse> GetPublicRoomsAsync() =>
            MakeRequestAsync(new ParameterlessRequest<PublicRoomsResponse>("client/{version}/publicRooms"));
    }
}
