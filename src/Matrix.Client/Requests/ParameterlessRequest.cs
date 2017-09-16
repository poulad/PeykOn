using System.Net.Http;
using Matrix.NET.Models;
using Newtonsoft.Json;

namespace Matrix.Client.Requests
{
    public class ParameterlessRequest<TResponse> : RequestBase<TResponse>
        where TResponse : IResponse, new()
    {
        public ParameterlessRequest(string parameterizedPath)
            : this(parameterizedPath, HttpMethod.Get, false)
        {
        }

        public ParameterlessRequest(string parameterizedPath, HttpMethod method)
            : this(parameterizedPath, method, false)
        {
        }

        public ParameterlessRequest(string parameterizedPath, HttpMethod method, bool requiresAuthToken)
            : base(parameterizedPath, method, requiresAuthToken)
        {
        }

        public override HttpContent GetHttpContent(JsonSerializerSettings serializerSettings) => null;
    }
}
