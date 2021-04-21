namespace MMT.Src.Mapping
{
    using AutoMapper;
    using MMT.Src.Data.Entities;
    using MMT.Src.DTOs;

    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}