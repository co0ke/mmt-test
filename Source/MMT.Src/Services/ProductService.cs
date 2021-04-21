namespace MMT.Src.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using MMT.Src.Data.Repositories;
    using MMT.Src.DTOs;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProductDTO>> GetFeaturedProducts()
        {
            var entities = await _repository.GetFeaturedProducts();
            var dtos = _mapper.Map<IList<ProductDTO>>(entities);
            return dtos;
        }

        public async Task<IList<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            var entities = await _repository.GetProductsByCategory(categoryId);
            var dtos = _mapper.Map<IList<ProductDTO>>(entities);
            return dtos;
        }
    }
}