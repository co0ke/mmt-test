namespace MMT.Api.IntegrationTests
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class ProductsEndpointTests : IClassFixture<WebApplicationFactory<MMT.API.Startup>>
    {
        private readonly WebApplicationFactory<MMT.API.Startup> _factory;

        public ProductsEndpointTests(WebApplicationFactory<MMT.API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/products/featured")]
        [InlineData("/products/category/2")]
        public async Task Products_ReturnsSuccessStatusCode(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/products/category/0")]
        public async Task ProductsByCategory_ReturnsUnprocessableEntityStatusCode(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}