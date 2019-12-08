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
        }
    }
}
