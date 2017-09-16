using System.Threading.Tasks;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.RoomListing)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class RoomListingTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public RoomListingTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.PublicRooms)]
        public async Task Should_Get_Public_Rooms()
        {
            var response = await Client.GetPublicRoomsAsync();

            Assert.NotNull(response);
            Assert.True(response.Chunk.Length > 1);
        }
    }
}
