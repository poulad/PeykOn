using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Matrix.Client.Tests.SysInteg.Common
{
    public static class ConfigurationProvider
    {
        public static TestConfigurations TestConfigurations;

        static ConfigurationProvider()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables("MatrixClient_")
                .Build();

            TestConfigurations = new TestConfigurations
            {
                UserName = configuration[nameof(TestConfigurations.UserName)],
                Password = configuration[nameof(TestConfigurations.Password)],
                RoomId = configuration[nameof(TestConfigurations.RoomId)],
            };

            if (string.IsNullOrWhiteSpace(TestConfigurations.UserName))
                throw new ArgumentNullException(nameof(TestConfigurations.UserName));

            if (string.IsNullOrWhiteSpace(TestConfigurations.Password))
                throw new ArgumentNullException(nameof(TestConfigurations.Password));
        }
    }
}
