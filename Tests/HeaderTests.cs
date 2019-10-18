using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class HeaderTests : IClassFixture<WebApplicationFactory<Accounts.Startup>>
{
    readonly WebApplicationFactory<Accounts.Startup> _factory;

    public HeaderTests(WebApplicationFactory<Accounts.Startup> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/accounts/8a799a3c-ab96-4517-bee4-bbe97a12b5c8")]
    public async Task Request_Fails_WithNoAccountId(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Theory]
    [InlineData("/accounts/8a799a3c-ab96-4517-bee4-bbe97a12b5c8")]
    public async Task Request_Fails_WithEmptyAccountId(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Account-Id", string.Empty);

        // Act
        var response = await client.SendAsync(request);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}