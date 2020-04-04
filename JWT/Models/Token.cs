using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JWT.Models
{
    public class Token
    {
        private readonly string _rawToken;

        public string Header { get; set; }
        public string Payload { get; set; }
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
    
                //Extract the headers of the JWT
                var headers = token.Header;
                var jwtHeader = "{";
                foreach(var h in headers)
                {
                    jwtHeader += '"' + h.Key + "\":\"" + h.Value + "\",";
                }
                jwtHeader += "}";
                Header = "Header:\r\n" + JToken.Parse(jwtHeader).ToString(Formatting.Indented);

                var claims = token.Claims;
                var jwtPayload = "{";
                foreach(Claim c in claims)
                {
                    jwtPayload += '"' + c.Type + "\":\"" + c.Value + "\",";
                }
                jwtPayload += "}";
                Payload = "\r\nPayload:\r\n" + JToken.Parse(jwtPayload).ToString(Formatting.Indented);

                Signature = "\r\nSignature:\r\n" + token.RawSignature;
            }   
        }
    }
}
