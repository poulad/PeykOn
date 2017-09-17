namespace Matrix.NET.Abstractions
{
    public static class Constants
    {
        public const string MajorVersion = "r0";

        public static class Routes
        {
            public const string BaseClientRoute = "_matrix/client";

            public const string BaseVersionedClientRoute = "_matrix/client/" + MajorVersion;

            public static class ApiStandards
            {
                public const string Versions = BaseClientRoute + "/versions";
            }

            public static class ClientAuthentication
            {
                public const string Registration = BaseVersionedClientRoute + "/register";
            }

            // todo

            public const string Login = "/_matrix/client/r0/login";

            public const string Logout = "/_matrix/client/r0/logout";

            public const string PublicRooms = "/_matrix/client/r0/publicRooms";

            public const string SendEvent = "/_matrix/client/r0/rooms/{roomId}/send/{eventType}/{txnId}";

            public const string UploadMedia = "/_matrix/media/r0/upload";
        }

        public static class Authentication
        {
            public static class Types
            {
                public const string PasswordBased = "m.login.password";

                public const string GoogleReCaptcha = "m.login.recaptcha";

                public const string TokenBased = "m.login.Token";

                public const string OAuth2Based = "m.login.oauth2";

                public const string EmailBased = "m.login.email.identity";

                public const string Dummy = "m.login.dummy";
            }
        }
    }
}
