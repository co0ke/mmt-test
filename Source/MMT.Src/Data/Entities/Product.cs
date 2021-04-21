namespace MMT.Src.Data.Entities
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
    }
}