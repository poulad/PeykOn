using System;
using Matrix.NET.Client.Requests;
using Matrix.NET.Models.Requests;

namespace Matrix.NET.Client.Tests.SysInteg.Common
{
    public class TestsFixture : IDisposable
    {
        public readonly IMatrixClient MatrixClient = new MatrixClient { ShouldValidateRequests = true };

        public TestsFixture()
        {
            var req = new LoginRequest(
                ConfigurationProvider.TestConfigurations.UserName,
                ConfigurationProvider.TestConfigurations.Password
            );

            MatrixClient.AccessToken = MatrixClient.LoginAsync(req).Result.AccessToken;
        }

        public void Dispose()
        {

        }
    }
}
