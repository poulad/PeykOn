using System.Net.Http;
using Newtonsoft.Json;

// ReSharper disable once UnusedTypeParameter
namespace Matrix.NET.Models
{
    public interface IRequest<TResponse>
        where TResponse : IResponse
    {
        HttpMethod Method { get; }

        string RelativePath { get; }

        bool RequiresAuthToken { get; }

        HttpContent GetHttpContent(JsonSerializerSettings serializerSettings);
    }
}
