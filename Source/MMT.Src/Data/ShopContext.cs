namespace MMT.Src.Data
{
    using Microsoft.EntityFrameworkCore;
    using MMT.Src.Constants;
    using MMT.Src.Data.Entities;

    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaNames.Shop);
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MMT.Src.AssemblyMarker).Assembly);
        }
    }
}
