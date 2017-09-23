using System.Threading.Tasks;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Responses;
using Matrix.NET.Models.Requests;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        #region 7.1 Creation

        public Task<string> CreateRoomAsync() => CreateRoomAsync(new CreateRoomRequest());
        
        public Task<string> CreateRoomAsync(CreateRoomRequest request) =>
            MakeRequestAsync(request)
                .ContinueWith(t => t.Result.RoomId);

        #endregion

        public Task<PublicRoomsResponse> GetPublicRoomsAsync() =>
            MakeRequestAsync(new ParameterlessRequest<PublicRoomsResponse>("client/{version}/publicRooms"));
    }
}