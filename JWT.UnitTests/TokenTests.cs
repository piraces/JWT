using JWT.Models;
using Xunit;

namespace JWT.UnitTests
{
    public class TokenTests
    {
        private const string ValidRawToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        private const string InvalidRawToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.";

        [Fact]
        public void Composing_Token_From_Valid_Raw_Token_Returns_Valid_Result()
        {
            var token = new Token(ValidRawToken);
            Assert.NotEmpty(token.Header);
            Assert.True(token.Header.Count == 2);
            Assert.True(token.Header[0].Key == "alg");
            Assert.NotEmpty(token.Header[0].KeyInfo);
            Assert.NotEmpty(token.Header[0].Value);
            Assert.True(token.Header[1].Key == "typ");
            Assert.NotEmpty(token.Header[1].KeyInfo);
            Assert.NotEmpty(token.Header[1].Value);

            Assert.NotEmpty(token.Payload);
            Assert.True(token.Payload.Count == 3);
            foreach (var item in token.Payload)
            {
                Assert.NotEmpty(item.Key);
                Assert.NotEmpty(item.KeyInfo);
                Assert.NotEmpty(item.Value);
            }
            Assert.False(string.IsNullOrWhiteSpace(token.Signature));
        }

        [Fact]
        public void Composing_Token_From_Invalid_Raw_Token_Returns_Valid_Result()
        {
            var token = new Token(InvalidRawToken);
            Assert.Null(token.Header);
            Assert.Null(token.Payload);
            Assert.True(string.IsNullOrWhiteSpace(token.Signature));
        }
    }
}
