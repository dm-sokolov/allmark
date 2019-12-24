using System.Linq;
using AllMark.Core.Models;
using AllMark.DTO;
using AutoMapper;

namespace AllMark.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoriesToString, opt => opt.MapFrom(src => string.Join("<br>", src.Categories.Select(i => i.Name).ToList())));
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
        }
    }
}
