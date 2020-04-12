using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace JWT.Models
{
    public class Token
    {
        private readonly string _rawToken;

        public List<JWTKeyValuePair> Header { get; set; }
        public List<JWTKeyValuePair> Payload { get; set; }
        public string Signature { get; set; }

        public Token(string rawToken)
        {
            _rawToken = rawToken;
            DecodeAndSetVariables();
        }

        private void DecodeAndSetVariables()
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtInput = _rawToken;

            var readableToken = jwtHandler.CanReadToken(jwtInput);

            if(readableToken)
            {
                var token = jwtHandler.ReadJwtToken(jwtInput);

                var headers = token.Header;
                Header = headers.Select(c => new JWTKeyValuePair {Key = c.Key, KeyInfo = "", Value = c.Value.ToString()}).ToList();

                var claims = token.Claims;
                Payload = claims.Select(c => new JWTKeyValuePair {Key = c.Type, KeyInfo = "", Value = c.Value}).ToList();

                Signature = token.RawSignature;
            }
        }
    }
}
