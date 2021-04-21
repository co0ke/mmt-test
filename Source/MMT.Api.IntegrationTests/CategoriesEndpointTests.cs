namespace MMT.Api.IntegrationTests
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class CategoriesEndpointTests : IClassFixture<WebApplicationFactory<MMT.API.Startup>>
    {
        private readonly WebApplicationFactory<MMT.API.Startup> _factory;

        public CategoriesEndpointTests(WebApplicationFactory<MMT.API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/categories")]
        public async Task Categories_ReturnsSuccessStatusCode(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}