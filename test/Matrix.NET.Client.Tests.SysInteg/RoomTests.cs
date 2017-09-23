using System.Linq;
using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.Rooms)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class RoomTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public RoomTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.Rooms.CreateRoom)]
        public async Task Should_Create_Private_Room()
        {
            string roomId = await Client.CreateRoomAsync();

            var expectedChars = new[] {'!', ':', '.'};
            Assert.Contains(roomId, c => expectedChars.Contains(c));
            Assert.StartsWith("!", roomId);
        }
        
        [Fact]
        [ExecutionOrder(2)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.Rooms.PublicRooms)]
        public async Task Should_Get_Public_Rooms()
        {
            var response = await Client.GetPublicRoomsAsync();

            Assert.NotNull(response);
            Assert.True(response.Chunk.Length > 1);
        }
    }
}