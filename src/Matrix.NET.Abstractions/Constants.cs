namespace Matrix.NET.Abstractions
{
    public static class Constants
    {
        public static class Routes
        {
            public const string BaseClientRoute = "_matrix/client";

            public static class ApiStandards
            {
                public const string Versions = BaseClientRoute + "/versions";
            }

            // todo

            public const string Login = "/_matrix/client/r0/login";

            public const string Logout = "/_matrix/client/r0/logout";

            public const string PublicRooms = "/_matrix/client/r0/publicRooms";

            public const string SendEvent = "/_matrix/client/r0/rooms/{roomId}/send/{eventType}/{txnId}";



            public const string UploadMedia = "/_matrix/media/r0/upload";
        }
    }
}
