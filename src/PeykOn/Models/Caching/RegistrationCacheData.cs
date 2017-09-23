using Matrix.NET.Models;
using Matrix.NET.Models.Requests;

namespace PeykOn.Models.Caching
{
    public class RegistrationCacheData
    {
        public UserAccountKind Kind { get; set; }
        
        public RegisterRequest<AuthenticationData> Request { set; get; }
    }
}