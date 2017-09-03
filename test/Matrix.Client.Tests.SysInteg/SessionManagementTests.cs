using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Tests.SysInteg.Common;
using Matrix.Client.Types;
using Newtonsoft.Json;
using Xunit;

namespace Matrix.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.SessionManagement)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class SessionManagementTests
    {
        private readonly TestsFixture _fixture;

        public SessionManagementTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.Login)]
        public async Task Should_Login_With_Password()
        {
            var req = new LoginRequest(
                ConfigurationProvider.TestConfigurations.UserName,
                ConfigurationProvider.TestConfigurations.Password
            );

            IMatrixClient sut = new MatrixClient();
            var login = await sut.LoginAsync(req);

            Assert.NotEmpty(login.AccessToken);

            _fixture.Login = login;
        }

        [Fact]
        [ExecutionOrder(2)]
        [Trait(CommonConstants.ApiRouteTraitName, CommonConstants.ApiRoutes.Login)]
        public void Should_Deserialize_LoginRequest()
        {
            const string json = @"{
                ""user"": ""@user:example.org"",
                ""password"": ""secret"",
                ""type"": ""m.login.password""
            }";
            var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(json);

            Assert.NotEmpty(loginRequest.User);
            Assert.NotEmpty(loginRequest.Password);
            Assert.Equal(loginRequest.Type, LoginType.Password);
        }
    }
}
