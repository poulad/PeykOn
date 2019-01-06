using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PeykOn.Federation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            const string server = "matrix.org";
            const string uri = "/_matrix/federation/v1/publicRooms";

            var httpClient = new HttpClient {BaseAddress = new Uri($"https://{server}", UriKind.Absolute)};
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add(
                "Authorization",
                MxCrypto.GetAuthorizationHeaderValue("GET", server, uri)
            );
            var response = await httpClient.SendAsync(request, HttpContext.RequestAborted);

            string responseContent = await response.Content.ReadAsStringAsync();
            JObject responseJson;
            try
            {
                responseJson = JsonConvert.DeserializeObject<JObject>(responseContent);
            }
            catch (JsonSerializationException)
            {
                responseJson = null;
            }

            return Json(new
            {
                request,
                response,
                responseContent,
                responseJson,
            });
        }
    }
}