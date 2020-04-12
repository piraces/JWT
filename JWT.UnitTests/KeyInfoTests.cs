using System.Security.Claims;
using IdentityModel;
using JWT.Models;
using JWT.UnitTests.Extensions;
using Xunit;

namespace JWT.UnitTests
{
    public class KeyInfoTests
    {
        [Fact]
        public void KeyInfo_Payload_Dictionary_Should_Contain_All_JwtClaimTypes()
        {
            var allJwtClaimTypes = typeof(JwtClaimTypes).GetAllPublicConstantValues<string>();
            foreach (var jwtClaimType in allJwtClaimTypes)
            {
                Assert.True(KeyInfo.KeyInfoPayload.TryGetValue(jwtClaimType, out _));
            }
        }

        [Fact]
        public void KeyInfo_Payload_Dictionary_Should_Contain_All_ClaimTypes()
        {
            var allClaimTypes = typeof(ClaimTypes).GetAllPublicConstantValues<string>();
            foreach (var claimType in allClaimTypes)
            {
                Assert.True(KeyInfo.KeyInfoPayload.TryGetValue(claimType, out _));
            }
        }
    }
}
