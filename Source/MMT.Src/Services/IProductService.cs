namespace MMT.Src.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MMT.Src.DTOs;

    public interface IProductService
    {
        Task<IList<ProductDTO>> GetFeaturedProducts();
        Task<IList<ProductDTO>> GetProductsByCategory(int categoryId);
    }
}