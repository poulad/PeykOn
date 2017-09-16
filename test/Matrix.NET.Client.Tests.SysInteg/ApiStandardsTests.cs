using System.Linq;
using System.Threading.Tasks;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.ApiStandards)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class ApiStandardsTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public ApiStandardsTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.Versions)]
        public async Task Should_Get_Versions()
        {
            var versions = await Client.GetVersionsAsync();

            Assert.NotEmpty(versions);
            Assert.True(versions.All(v => v.StartsWith("r0.")));
        }
    }
}
