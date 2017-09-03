using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            HomeserverUrl = $"{homeserverUrl}/_matrix/client/";
            _httpClient = new HttpClient { BaseAddress = new Uri(HomeserverUrl) };
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        public Task<string[]> GetVersionsAsync() =>
            MakeRequestAsync<string[]>("versions", HttpMethod.Get);

        private Task<T> MakeRequestAsync<T>
            (string uri, HttpMethod method, bool requiresAccessToken = false, object data = null)
        {
            Task<string> EnsureSuccessResponse(Task<HttpResponseMessage> t)
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

            if (requiresAccessToken)
            {
                uri += $"?access_token={AccessToken}";
            }

            var request = new HttpRequestMessage(method, uri);
            if (data != null)
            {
                string payload = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
                request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            }

            return _httpClient
                .SendAsync(request)
                    .ContinueWith(EnsureSuccessResponse)
                    .ContinueWith(t => JsonConvert.DeserializeObject<T>(t.Result.Result, _jsonSerializerSettings));
        }
    }
}
