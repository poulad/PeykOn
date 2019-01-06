using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PeykOn.Federation
{
    public class Program
    {
        public const string ServerName = "poulad.ml";
        public const string PrivateKeyBase64 = "9QkYteyWXrXAOtUj9+iGTKjiV/m1WiaF19jVjOvOmNM=";
        public const string PrivateKeyUnpaddedBase64 = "9QkYteyWXrXAOtUj9+iGTKjiV/m1WiaF19jVjOvOmNM";
        public const string PublicKeyUnpaddedBase64 = "n1sU1k3S+auzhXbEp4iQkUwToQE3YBx0k2CYVXjr5T4";

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}