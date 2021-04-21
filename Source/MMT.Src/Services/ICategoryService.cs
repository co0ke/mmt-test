namespace MMT.Src.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MMT.Src.DTOs;

    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetCategories();
    }
}