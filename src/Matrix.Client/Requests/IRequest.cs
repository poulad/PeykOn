using System.Net.Http;
using Matrix.Client.Responses;
using Newtonsoft.Json;

namespace Matrix.Client.Requests
{
    public interface IRequest<TResponse>
        where TResponse : IResponse, new()
    {
        HttpMethod Method { get; }

        string RelativePath { get; }

        bool RequiresAuthToken { get; }

        HttpContent GetHttpContent(JsonSerializerSettings serializerSettings);
    }
}
