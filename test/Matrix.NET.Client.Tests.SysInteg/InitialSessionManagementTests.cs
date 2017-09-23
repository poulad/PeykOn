using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Matrix.NET.Models;
using Matrix.NET.Models.Requests;
using Newtonsoft.Json;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.InitialSessionManagement)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class InitialSessionManagementTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public InitialSessionManagementTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.ClientAuthentication.Login)]
        public async Task Should_Login_With_Password()
        {
            var req = new LoginRequest(
                ConfigurationProvider.TestConfigurations.UserName,
                ConfigurationProvider.TestConfigurations.Password
            );

            var login = await Client.LoginAsync(req);

            Assert.NotEmpty(login.AccessToken);

            Client.AccessToken = login.AccessToken;
        }

        [Fact]
        [ExecutionOrder(2)]
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
            Assert.Equal(loginRequest.Type, AuthenticationType.PasswordBased);
        }
    }
}
