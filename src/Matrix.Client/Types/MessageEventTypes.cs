namespace Matrix.Client.Types
{
    public static class MessageEventTypes
    {
        public const string Text = "m.text";

        public const string Image = "m.image";

        public static string[] All =
        {
            Text,
            Image,
        };
    }
}
