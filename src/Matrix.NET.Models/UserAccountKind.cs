namespace Matrix.NET.Models
{
    //[JsonConverter(typeof(StringEnumConverter), true)]
    public enum UserAccountKind
    {
        /// <summary>
        /// user accounts. These accounts may use the full API described in this specification.
        /// </summary>
        User = 0,

        /// <summary>
        /// guest accounts. These accounts may have limited permissions and may not be supported by all servers.
        /// </summary>
        Guest = 1,
    }
}
