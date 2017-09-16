namespace Matrix.NET.Models
{
    public static class Constants
    {
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
