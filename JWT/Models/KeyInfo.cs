using System.Collections.Generic;

namespace JWT.Models
{
    public static class KeyInfo
    {
        public static Dictionary<string, string> KeyInfoHeader = new Dictionary<string, string>
        {
            { "alg", "Signature / Encryption algorithm" },
            { "typ", "Type of Token" },
            { "cty", "Content Type. Used to convey information about the JWT" }
        };

        public static Dictionary<string, string> KeyInfoPayload = new Dictionary<string, string>
        {
            { "iss", "Issuer. Identifies the principal that issued the JWT" },
            { "exp", "Expiration time. Identifies the expiration time on or after which the JWT must not be accepted for processing (seconds since UNIX Epoch)" },
            { "sub", "Subject. Identifies the principal that is the subject of the JWT" },
            { "aud", "Audience. Identifies the recipients that the JWT is intended for" },
            { "nbf", "Not before. Identifies the time before which the JWT must not be accepted for processing" },
            { "iat", "Issued At. Identifies the time at which the JWT was issued" },
            { "jti", "JWT ID. Provides an unique identifier for the JWT." },
        };
    }
}
