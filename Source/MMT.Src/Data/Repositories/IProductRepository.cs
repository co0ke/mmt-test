namespace MMT.Src.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MMT.Src.Data.Entities;

    public interface IProductRepository
    {
        Task<IList<Product>> GetFeaturedProducts();
        Task<IList<Product>> GetProductsByCategory(int categoryId);
    }
}