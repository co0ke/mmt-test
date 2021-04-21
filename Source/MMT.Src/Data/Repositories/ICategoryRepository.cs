namespace MMT.Src.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MMT.Src.Data.Entities;

    public interface ICategoryRepository
    {
        Task<IList<Category>> GetCategories();
    }
}