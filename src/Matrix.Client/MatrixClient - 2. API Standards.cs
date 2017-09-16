using System.Threading.Tasks;
using Matrix.Client.Requests;
using Matrix.Client.Responses;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<string[]> GetVersionsAsync() =>
            MakeRequestAsync(new ParameterlessRequest<VersionsResponse>("client/versions"))
                .ContinueWith(t => t.Result.Versions);
    }
}
