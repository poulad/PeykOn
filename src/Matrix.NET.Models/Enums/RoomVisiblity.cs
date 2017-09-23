using System.Runtime.Serialization;
using Matrix.NET.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Matrix.NET.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomVisiblity
    {
        [EnumMember(Value = Constants.Room.Visiblity.Private)]
        Private,
        
        [EnumMember(Value = Constants.Room.Visiblity.Public)]
        Public,
    }
}