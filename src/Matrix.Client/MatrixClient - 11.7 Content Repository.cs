using System.Threading.Tasks;
using Matrix.Client.Requests;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<string> UploadMediaAsync(MediaUploadRequest request) =>
            MakeRequestAsync(request)
            .ContinueWith(t => t.Result.ContentUri);
    }
}
