namespace Matrix.Client.Tests.SysInteg.Common
{
    public static class CommonConstants
    {
        public const string AssemblyName = "Matrix.Client.Tests.SysInteg";

        public const string TestCaseOrdererName = AssemblyName + ".Common.TestCaseOrderer";

        public const string ApiRouteTraitName = "ApiRoute";

        public static class TestCollections
        {
            public const string InitialSessionManagement = "Session management - Initial";

            public const string ApiStandards = "API Standards";

            public const string RoomListing = "Listing rooms";

            public const string EventSending = "Event sending";

            public const string FinalSessionManagement = "Session management - Final";

            public const string ContentRepository = "Content Repository";
        }

        public static class ApiRoutes
        {
            public const string Login = "/_matrix/client/r0/login";

            public const string Logout = "/_matrix/client/r0/logout";

            public const string PublicRooms = "/_matrix/client/r0/publicRooms";

            public const string SendEvent = "/_matrix/client/r0/rooms/{roomId}/send/{eventType}/{txnId}";

            public const string Versions = "/_matrix/client/versions";

            public const string UploadMedia = "/_matrix/media/r0/upload";
        }
    }
}