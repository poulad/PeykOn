using System;
using System.Net.Http;
using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Matrix.Client
{
    public partial class MatrixClient : IMatrixClient
    {
        public string HomeserverUrl { get; }

        public string AccessToken { get; set; }

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private readonly HttpClient _httpClient;

        private readonly string _apiVersion;

        public MatrixClient()
            : this("https://www.matrix.org")
        {

        }

        public MatrixClient(string homeserverUrl)
            : this(homeserverUrl, "r0")
        {

        }

        public MatrixClient(string homeserverUrl, string apiVersion)
        {
            _apiVersion = apiVersion;
            HomeserverUrl = $"{homeserverUrl}/_matrix/";
            _httpClient = new HttpClient { BaseAddress = new Uri(HomeserverUrl) };

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        private Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse, new()
        {
            string uri = request.RelativePath.Replace("{version}", _apiVersion);
            if (request.RequiresAuthToken)
            {
                if (string.IsNullOrWhiteSpace(AccessToken))
                    throw new NullReferenceException(nameof(AccessToken));

                uri = uri.Replace("{accessToken}", AccessToken);
            }

            var requestMessage = new HttpRequestMessage(request.Method, uri);

            //if (request.RequiresSerialization)
            {
                requestMessage.Content = request.GetHttpContent(_jsonSerializerSettings);
            }

            return _httpClient
                .SendAsync(requestMessage)
                .ContinueWith(EnsureSuccessResponse)
                .ContinueWith(t => JsonConvert.DeserializeObject<TResponse>(t.Result.Result, _jsonSerializerSettings));
        }

        private static Task<string> EnsureSuccessResponse(Task<HttpResponseMessage> t)
        {
            if (t.Result.IsSuccessStatusCode)
            {
                return t.Result.Content.ReadAsStringAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
