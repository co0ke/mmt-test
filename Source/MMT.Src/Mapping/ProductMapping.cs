namespace MMT.Src.Mapping
{
    using AutoMapper;
    using MMT.Src.Data.Entities;
    using MMT.Src.DTOs;

    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}