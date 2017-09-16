using System.Threading.Tasks;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Responses;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        #region 7.1 Creation

        public Task CreateRoomAsync(CreateRoomRequest request) => // ToDo
            MakeRequestAsync(request);

        #endregion

        public Task<PublicRoomsResponse> GetPublicRoomsAsync() =>
            MakeRequestAsync(new ParameterlessRequest<PublicRoomsResponse>("client/{version}/publicRooms"));
    }
}
