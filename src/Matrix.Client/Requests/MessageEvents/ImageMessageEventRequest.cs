using System.ComponentModel.DataAnnotations;
using Matrix.Client.Types;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace Matrix.Client.Requests
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageMessageEventRequest : MessageEventRequestBase
    {
        [JsonProperty("msgtype", Required = Required.Always)]
        public override string MsgType => MessageEventTypes.Image;

        [Required]
        [JsonProperty(Required = Required.Always)]
        public sealed override string Body { get; set; }

        [Required]
        [JsonProperty(Required = Required.Always)]
        public string Url { get; set; }

        //[JsonProperty]
        //public ImageInfo Info { get; set; } // ToDo

        public ImageMessageEventRequest(string roomId, string txnId)
            : this(roomId, txnId, null, null)
        {
        }

        public ImageMessageEventRequest(string roomId, string txnId, string text)
            : this(roomId, txnId, text, null)
        {
        }

        public ImageMessageEventRequest(string roomId, string txnId, string text, string url)
        {
            RoomId = roomId;
            TxnId = txnId;
            Body = text;
            Url = url;
        }
    }
}
