using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PeykOn.Federation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            const string url = "/_matrix/federation/v1/publicRooms";

            var httpClient = new HttpClient {BaseAddress = new Uri("https://matrix.org", UriKind.Absolute)};
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", MxCrypto.GetAuthorizationHeaderValue("GET", url));
            var response = await httpClient.SendAsync(request, HttpContext.RequestAborted);

            string json = null;
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
            }

            return Json(new
            {
                request,
                response,
                json
            });
        }
    }
}