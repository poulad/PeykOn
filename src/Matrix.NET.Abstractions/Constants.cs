namespace Matrix.NET.Abstractions
{
    public static class Constants
    {
        public const string MajorVersion = "r0";

        public static class Routes
        {
            private const string BaseClientRoute = "_matrix/client";

            private const string BaseVersionedClientRoute = "_matrix/client/" + MajorVersion;
            
            private const string BaseVersionedMediaRoute = "_matrix/media/" + MajorVersion;

            public static class ApiStandards
            {
                public const string Versions = BaseClientRoute + "/versions";
            }

            public static class ClientAuthentication
            {
                public const string Registration = BaseVersionedClientRoute + "/register";

                public const string Login = BaseVersionedClientRoute + "/login";

                public const string Logout = BaseVersionedClientRoute + "/logout";
            }

            public static class Events
            {
                private const string RoomsRoute = BaseVersionedClientRoute + "/rooms/{roomId}";
                
                public const string State = RoomsRoute + "/state";
                
                public const string EventType = State + "/{eventType}";
                
                public const string StateKey = EventType + "/{stateKey}";
                
                public const string TxnId = EventType + "/{txnId}";
            }
            
            public static class Rooms
            {
                public const string CreateRoom = BaseVersionedClientRoute + "/createRoom";
                
                public const string PublicRooms = BaseVersionedClientRoute + "/publicRooms";
            }

            public static class ContentRepository
            {
                public const string Upload = BaseVersionedMediaRoute + "/upload";
            }
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

        public static class Room
        {
            public static class Visiblity
            {
                public const string Public = "public";

                public const string Private = "private";
            }

            public static class Preset
            {
                public const string PrivateChat = "private_chat";

                public const string TrustedPrivateChat = "trusted_private_chat";

                public const string PublicChat = "public_chat";
            }
        }
    }
}