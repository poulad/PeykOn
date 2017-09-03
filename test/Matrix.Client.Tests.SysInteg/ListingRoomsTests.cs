using System.Threading.Tasks;
using Matrix.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.ListingRooms)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class ListingRoomsTests
    {
        private readonly TestsFixture _fixture;

        public ListingRoomsTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.PublicRooms)]
        public async Task Should_Get_Public_Rooms()
        {
            IMatrixClient sut = new MatrixClient();
            var response = await sut.GetPublicRoomsAsync();

            Assert.NotNull(response);
            Assert.True(response.Chunk.Length > 1);
        }
    }
}
