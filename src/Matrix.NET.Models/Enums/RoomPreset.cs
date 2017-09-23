using System.Runtime.Serialization;
using Matrix.NET.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Matrix.NET.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomPreset
    {
        [EnumMember(Value = Constants.Room.Preset.PrivateChat)]
        PrivateChat,
        
        [EnumMember(Value = Constants.Room.Preset.TrustedPrivateChat)]
        TrustedPrivateChat,
        
        [EnumMember(Value = Constants.Room.Preset.PublicChat)]
        PublicChat,
    }
}