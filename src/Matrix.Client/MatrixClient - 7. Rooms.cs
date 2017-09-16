using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
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
