using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PeykOn.Federation.Controllers
{
    [Route("_matrix/key/v2/server")]
    [ApiController]
    public class ServerKeysController : Controller
    {
        [HttpGet]
        [HttpGet("{keyId}")]
        public async Task<ActionResult> Get(
            string keyId = default
        )
        {
            byte[] serverCertHash = await GetCertificateSha256HashAsync(Program.ServerName)
                .ConfigureAwait(false);

            var keys = new
            {
                old_verify_keys = new { },
                server_name = Program.ServerName,
                tls_fingerprints = new[]
                {
                    new
                    {
                        sha256 = MxCrypto.EncodeToUnpaddedBase64(serverCertHash)
                    }
                },
                valid_until_ts = 1746810709, // Friday, May 9, 2025 5:11:49 PM
                verify_keys = new Dictionary<string, object>
                {
                    {"ed25519:foo", new {key = Program.PublicKeyUnpaddedBase64}}
                },
            };

            var jObject = MxCrypto.GetSignedJson(keys);

            return Json(jObject, new JsonSerializerSettings {Formatting = Formatting.None});
        }

        private static async Task<byte[]> GetCertificateSha256HashAsync(string server)
        {
            byte[] sha256CertificateHash = null;
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, cert, __, ___) =>
                {
                    sha256CertificateHash = cert.GetCertHash(HashAlgorithmName.SHA256);
                    return true;
                }
            };

            var httpClient = new HttpClient(httpClientHandler);
            var request = new HttpRequestMessage(HttpMethod.Head, $"https://{server}");
            await httpClient.SendAsync(request).ConfigureAwait(false);

            return sha256CertificateHash;
        }
    }
}