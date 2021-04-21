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

    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetCategories_ReturnsExpectedResult()
        {
            // Arrange
            var categoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            var mapper = new Mock<IMapper>(MockBehavior.Strict);
            var service = new CategoryService(categoryRepository.Object, mapper.Object);

            var entities = new List<Category>();
            categoryRepository
                .Setup(x => x.GetCategories())
                .ReturnsAsync(entities);

            var dtos = new List<CategoryDTO>();
            mapper
                .Setup(x => x.Map<IList<CategoryDTO>>(entities))
                .Returns(dtos);

            // Act
            var result = await service.GetCategories();

            // Assert
            result.Should().BeSameAs(dtos);
            categoryRepository.Verify(x => x.GetCategories(), Times.Once);
            mapper.Verify(x => x.Map<IList<CategoryDTO>>(entities), Times.Once);
        }
    }
}