using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Matrix.NET.Models;

namespace Matrix.Client
{
    public partial class MatrixClient : IMatrixClient
    {
        public string HomeserverUrl { get; }

        public string AccessToken { get; set; }

        public bool ShouldValidateRequests { get; set; }

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private readonly HttpClient _httpClient;

        private readonly string _apiVersion;

        public MatrixClient()
            : this("https://www.matrix.org")
        { }

        public MatrixClient(string homeserverUrl)
            : this(homeserverUrl, "r0")
        { }

        public MatrixClient(string homeserverUrl, string apiVersion)
        {
            _apiVersion = apiVersion;
            HomeserverUrl = homeserverUrl;
            _httpClient = new HttpClient { BaseAddress = new Uri($"{homeserverUrl}/_matrix/") };

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        public (bool IsValid, IEnumerable<ValidationResult> ValidationResults) TryValidateRquest<TResponse>(
            IRequest<TResponse> request)
            where TResponse : IResponse
        {
            var vc = new ValidationContext(request);
            var vResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(request, vc, vResults);
            return (isValid, vResults);
        }

        public Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse
        {
            if (ShouldValidateRequests && !TryValidateRquest(request).IsValid)
            {
                throw new ValidationException("Request is not valid");
            }

            string uri = request.RelativePath.Replace("{version}", _apiVersion);
            if (request.RequiresAuthToken)
            {
                if (string.IsNullOrWhiteSpace(AccessToken))
                    throw new NullReferenceException(nameof(AccessToken));

                uri = uri.Replace("{accessToken}", AccessToken);
            }

            var requestMessage = new HttpRequestMessage(request.Method, uri)
            {
                Content = request.GetHttpContent(_jsonSerializerSettings)
            };

            return _httpClient
                .SendAsync(requestMessage)
                .ContinueWith(t => ReadResponse(t, true))
                .ContinueWith(t => JsonConvert.DeserializeObject<TResponse>(t.Result.Result, _jsonSerializerSettings));
        }

        public Task<TResponse> MakeRequestAsync<TResponse>
            (IRequest<TResponse> request, bool requiresSuccessStatusCode, params Type[] responseTypes)
            where TResponse : class, IResponse
        {
            if (ShouldValidateRequests && !TryValidateRquest(request).IsValid)
            {
                throw new ValidationException("Request is not valid");
            }

            string uri = request.RelativePath.Replace("{version}", _apiVersion);
            if (request.RequiresAuthToken)
            {
                if (string.IsNullOrWhiteSpace(AccessToken))
                    throw new NullReferenceException(nameof(AccessToken));

                uri = uri.Replace("{accessToken}", AccessToken);
            }

            var requestMessage = new HttpRequestMessage(request.Method, uri)
            {
                Content = request.GetHttpContent(_jsonSerializerSettings)
            };

            return _httpClient
                .SendAsync(requestMessage)
                .ContinueWith(t => ReadResponse(t, requiresSuccessStatusCode))
                .ContinueWith(t => DeserializeJson<TResponse>(t.Result, responseTypes));
        }

        private static Task<string> ReadResponse(Task<HttpResponseMessage> t, bool requiresSuccessStatusCode) =>
            requiresSuccessStatusCode && !t.Result.IsSuccessStatusCode
                ? throw new NotImplementedException()
                : t.Result.Content.ReadAsStringAsync()
            ;

        private TBase DeserializeJson<TBase>(Task<string> jsonTask, params Type[] types)
            where TBase : class
            => (TBase)types
                .Select(type => JsonConvert.DeserializeObject(jsonTask.Result, type, _jsonSerializerSettings))
                .FirstOrDefault(o => o != null) ??
               JsonConvert.DeserializeObject<TBase>(jsonTask.Result, _jsonSerializerSettings)
            ;
    }
}
