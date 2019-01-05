using System.Collections.Generic;
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
        public ActionResult Get(
            string keyId = default
        )
        {
//            var keys = new
//            {
//                server_name = "peykon.herokuapp.com",
//                tls_fingerprints = new
//                {
//                    sha256 =
//                        "MkY6MEU6NDg6MjQ6Rjg6QkE6MDU6M0U6NDI6NDA6Nzc6NzY6NTU6NjE6NTA6RjA6MkE6REE6NTg6RDI6MDU6RkI6MTY6OTA6Qjg6MUQ6QTY6NkQ6REQ6NzY6QzE6RTQ"
//                },
//                valid_until_ts = 1262667291, // Jan 2010
//                verify_keys = new Dictionary<string, object>
//                {
//                    {"ed25519:foo", new {key = "n1sU1k3S+auzhXbEp4iQkUwToQE3YBx0k2CYVXjr5T4"}}
//                },
//            };

//            string unsignedJson = JsonConvert.SerializeObject(keys);
//            string signedJson = MxCrypto.SignJson(keys);

            var response = new
            {
                server_name = "peykon.herokuapp.com",
                signatures = new Dictionary<string, object>
                {
                    {
                        "peykon.herokuapp.com", new Dictionary<string, object>
                        {
                            {
                                "ed25519:foo",
                                "U8k5mC/Q4O8iPoEyo7EHNXnmidePIOXqEIdztX+UpMNDdN5HDBGjGFjRlNYTbhuLWUIWlqzS5b6B4biaobBtAg"
                            }
                        }
                    }
                },
                tls_fingerprints = new
                {
                    sha256 =
                        "MkY6MEU6NDg6MjQ6Rjg6QkE6MDU6M0U6NDI6NDA6Nzc6NzY6NTU6NjE6NTA6RjA6MkE6REE6NTg6RDI6MDU6RkI6MTY6OTA6Qjg6MUQ6QTY6NkQ6REQ6NzY6QzE6RTQ"
                },
                valid_until_ts = 1262667291, // Jan 2010
                verify_keys = new Dictionary<string, object>
                {
                    {"ed25519:foo", new {key = "n1sU1k3S+auzhXbEp4iQkUwToQE3YBx0k2CYVXjr5T4"}}
                },
            };

            return Json(response, new JsonSerializerSettings {Formatting = Formatting.None});
        }
    }
}