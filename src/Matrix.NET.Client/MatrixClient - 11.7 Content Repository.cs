using System.Threading.Tasks;
using Matrix.NET.Client.Requests;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        public Task<string> UploadMediaAsync(MediaUploadRequest request) =>
            MakeRequestAsync(request)
            .ContinueWith(t => t.Result.ContentUri);
    }
}
