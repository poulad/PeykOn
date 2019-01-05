using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PeykOn.Federation.Controllers
{
    [Route("_matrix/federation/v1/version")]
    [ApiController]
    public class ServerInfoController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var response = new
            {
                server = new
                {
                    name = "peykon.herokuapp.com:443",
                    version = "0.0.0-alpha1"
                }
            };

            return Json(response, new JsonSerializerSettings {Formatting = Formatting.None});
        }
    }
}