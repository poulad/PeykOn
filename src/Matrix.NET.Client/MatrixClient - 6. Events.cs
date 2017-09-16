using System.Threading.Tasks;
using Matrix.NET.Client.Requests;

namespace Matrix.NET.Client
{
    public partial class MatrixClient
    {
        public Task<string> SendMessageEventAsync(MessageEventRequestBase messageEventRequest) =>
            MakeRequestAsync(messageEventRequest)
            .ContinueWith(t => t.Result.EventId);
    }
}
