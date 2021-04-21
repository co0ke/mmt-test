namespace MMT.Src.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using MMT.Src.Data.Repositories;
    using MMT.Src.DTOs;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDTO>> GetCategories()
        {
            var entities = await _repository.GetCategories();
            var dtos = _mapper.Map<IList<CategoryDTO>>(entities);
            return dtos;
        }
    }
}