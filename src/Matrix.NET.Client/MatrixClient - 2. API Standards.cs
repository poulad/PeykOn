using System.Threading.Tasks;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Responses;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        public Task<string[]> GetVersionsAsync() =>
            MakeRequestAsync(new ParameterlessRequest<VersionsResponse>("client/versions"))
                .ContinueWith(t => t.Result.Versions);
    }
}
