using AllMark.Core.Models;
using AllMark.DTO;
using AutoMapper;

namespace AllMark.AutoMapper.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                //.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => new List<Category> { new Category { CategoryId = src.CategoryId } }));
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
        }
    }
}
