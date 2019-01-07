using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PeykOn.Federation
{
    public class Program
    {
        public const string ServerName = "poulad.ml";
        public const string PrivateKeyBase64 = "GF1ktpR54LoKWEShCthBJboRxLQNY+2ixXr8fgGcjgw=";
        public const string PrivateKeyUnpaddedBase64 = "GF1ktpR54LoKWEShCthBJboRxLQNY+2ixXr8fgGcjgw";
        public const string PublicKeyUnpaddedBase64 = "pXZPY5ilriJmo4+XFFM8S72NB4JvY+IEy6w3SwrO8b0";

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}