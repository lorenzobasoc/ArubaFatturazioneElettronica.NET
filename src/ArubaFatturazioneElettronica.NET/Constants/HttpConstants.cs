namespace ArubaFatturazioneElettronica.NET.Constants;

public class HttpConstants
{
    public static class Auth
    {
        public const string AUTH_BEARER = "Bearer";
    }

    public static class BodyContent
    {
        public const string GRANT_TYPE = "grant_type";
        public const string REFRESH_TOKEN = "refresh_token";
        public const string USERNAME = "username";
        public const string PASSWORD = "password";
    }
}
