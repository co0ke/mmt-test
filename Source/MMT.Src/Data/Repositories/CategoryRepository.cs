namespace MMT.Src.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MMT.Src.Constants;
    using MMT.Src.Data.Entities;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await _context.Categories
                .FromSqlRaw($"{SchemaNames.Shop}.{StoredProcedureNames.GetAvailableCategories}")
                .ToListAsync();
        }
    }
}
