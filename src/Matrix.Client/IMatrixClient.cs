using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public interface IMatrixClient
    {
        string HomeserverUrl { get; }

        string AccessToken { get; set; }

        bool ShouldValidateRequests { get; set; }

        (bool IsValid, IEnumerable<ValidationResult> ValidationResults) TryValidateRquest<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse, new();

        Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse, new();

        #region 2. API Standards

        Task<string[]> GetVersionsAsync();

        #endregion

        #region 3. Client Authentication

        Task<Login> LoginAsync(LoginRequest request);

        Task LogoutAsync();

        #endregion

        #region 6. Events

        Task<string> SendMessageEventAsync(MessageEventRequestBase messageEventRequest);

        #endregion

        #region 7. Rooms

        Task<PublicRoomsResponse> GetPublicRoomsAsync();

        #endregion

        #region 11. Modules

        #region 11.7 Content Repository

        Task<string> UploadMediaAsync(MediaUploadRequest request);


        #endregion

        #endregion
    }
}
