using Newtonsoft.Json;

namespace Matrix.NET.Models.Types
{
    // ToDo this is the same as m.room.create event   
    public class RoomCreationContent
    {
        public string Creator { get; set; }

        [JsonProperty("m.federate")]
        public bool? Federate { get; set; }
    }
}