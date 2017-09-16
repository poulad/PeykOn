using System.Threading.Tasks;
using Matrix.Client.Requests;

namespace Matrix.Client
{
    public partial class MatrixClient
    {
        public Task<string> SendMessageEventAsync(MessageEventRequestBase messageEventRequest) =>
            MakeRequestAsync(messageEventRequest)
            .ContinueWith(t => t.Result.EventId);
    }
}
