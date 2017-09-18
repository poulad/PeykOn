using System.Net;
using Newtonsoft.Json;

namespace Matrix.NET.Models
{
    public abstract class ResponseBase : IResponse
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.OK;

        protected ResponseBase()
        {
        }

        protected ResponseBase(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}