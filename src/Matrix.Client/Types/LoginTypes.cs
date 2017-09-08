namespace Matrix.Client.Types
{
    public static class LoginTypes
    {
        public const string Password = "m.login.password";

        public const string Token = "m.login.token";

        public static string[] All =
        {
            Password,
            Token,
        };
    }
}
