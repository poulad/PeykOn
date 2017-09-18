using Matrix.NET.Models;
using Matrix.NET.Models.Requests;

namespace PeykOn.Models.Caching
{
    public class RegistrationCacheData
    {
        public RegisterRequest<AuthenticationData> Request { set; get; }
    }
}