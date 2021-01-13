using AutoMapper;
using Domain;
using Domain.DTOs;

namespace Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}