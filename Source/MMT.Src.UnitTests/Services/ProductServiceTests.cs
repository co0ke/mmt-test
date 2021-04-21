namespace MMT.Src.UnitTests.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using MMT.Src.Data.Entities;
    using MMT.Src.Data.Repositories;
    using MMT.Src.DTOs;
    using MMT.Src.Services;
    using Moq;
    using Xunit;

    public class ProductServiceTests
    {
        [Fact]
        public async Task GetFeaturedProducts_ReturnsExpectedResult()
        {
            // Arrange
            var repository = new Mock<IProductRepository>(MockBehavior.Strict);
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var service = new ProductService(repository.Object, mapper.Object);

            var entities = new List<Product>();
            repository
                .Setup(x => x.GetFeaturedProducts())
                .ReturnsAsync(entities);

            var dtos = new List<ProductDTO>();
            mapper
                .Setup(x => x.Map<IList<ProductDTO>>(entities))
                .Returns(dtos);

            // Act
            var result = await service.GetFeaturedProducts();

            // Assert
            result.Should().BeSameAs(dtos);
            repository.Verify(x => x.GetFeaturedProducts(), Times.Once);
            mapper.Verify(x => x.Map<IList<ProductDTO>>(entities), Times.Once);
        }

        [Fact]
        public async Task GetProductsByCategory_ReturnsExpectedResult()
        {
            // Arrange
            var repository = new Mock<IProductRepository>(MockBehavior.Strict);
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var service = new ProductService(repository.Object, mapper.Object);
            var categoryId = 2;

            var entities = new List<Product>();
            repository
                .Setup(x => x.GetProductsByCategory(categoryId))
                .ReturnsAsync(entities);

            var dtos = new List<ProductDTO>();
            mapper
                .Setup(x => x.Map<IList<ProductDTO>>(entities))
                .Returns(dtos);

            // Act
            var result = await service.GetProductsByCategory(categoryId);

            // Assert
            result.Should().BeSameAs(dtos);
            repository.Verify(x => x.GetProductsByCategory(categoryId), Times.Once);
            mapper.Verify(x => x.Map<IList<ProductDTO>>(entities), Times.Once);
        }
    }
}