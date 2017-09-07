using System.Threading.Tasks;
using Matrix.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.FinalSessionManagement)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class FinalSessionManagementTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public FinalSessionManagementTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.Logout)]
        public async Task Should_Logout()
        {
            await Client.LogoutAsync();
        }
    }
}
