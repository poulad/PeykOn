using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Matrix.NET.Models
{
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
        where TResponse : IResponse
    {
        public HttpMethod Method { get; }

        public string RelativePath =>
            PathParameters.Aggregate(_parameterizedPath,
                (current, pair) => current.Replace($"{{{pair.Key}}}", pair.Value));

        public bool RequiresAuthToken { get; }

        protected internal readonly Dictionary<string, string> PathParameters = new Dictionary<string, string>(5);

        private readonly string _parameterizedPath;

        protected RequestBase(string parameterizedPath, HttpMethod method, bool requiresAuthToken)
        {
            _parameterizedPath = parameterizedPath;
            Method = method;
            RequiresAuthToken = requiresAuthToken;
        }

        public virtual HttpContent GetHttpContent(JsonSerializerSettings serializerSettings)
        {
            string payload = JsonConvert.SerializeObject(this, serializerSettings);
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
