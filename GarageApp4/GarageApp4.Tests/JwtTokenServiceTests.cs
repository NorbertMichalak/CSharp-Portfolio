using GarageApp4.Models;
using GarageApp4.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Xunit;

namespace GarageApp4.Tests;

public class JwtTokenServiceTests
{
    [Fact]
    public void GenerateToken_ValidUser_ReturnsTokenWithIssuerAndAudience()
    {
        // Arrange
        var settings = new Dictionary<string, string?>
        {
            ["Jwt:Key"] = "test-key-minimum-32-symbols-1234567890",
            ["Jwt:Issuer"] = "TestIssuer",
            ["Jwt:Audience"] = "TestAudience"
        };

        IConfiguration config = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();

        var service = new JwtTokenService(config);
        var user = new User { Id = 1, Username = "norbert" };

        // Act
        var token = service.GenerateToken(user);

        var jwt = new JsonWebToken(token);
        Assert.Equal("TestIssuer", jwt.Issuer);
        Assert.Contains("TestAudience", jwt.Audiences);

        
    }
}