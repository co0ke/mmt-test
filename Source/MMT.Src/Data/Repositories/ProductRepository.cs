namespace MMT.Src.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using MMT.Src.Constants;
    using MMT.Src.Data.Entities;

    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> GetFeaturedProducts()
        {
            return await _context.Products
                .FromSqlRaw($"{SchemaNames.Shop}.{StoredProcedureNames.GetFeaturedProducts}")
                .ToListAsync();
        }

        public async Task<IList<Product>> GetProductsByCategory(int categoryId)
        {
            var categoryIdParam = new SqlParameter("CategoryID", categoryId);

            return await _context.Products
                .FromSqlRaw($"{SchemaNames.Shop}.{StoredProcedureNames.GetProductsByCategory} @CategoryID", categoryIdParam)
                .ToListAsync();
        }
    }
}
