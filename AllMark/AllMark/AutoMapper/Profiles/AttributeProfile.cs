using AllMark.Core.Models;
using AllMark.DTO;
using AutoMapper;

namespace AllMark.AutoMapper.Profiles
{
    public class AttributeProfile: Profile
    {
        public AttributeProfile()
        {
            CreateMap<ProductAttribute, AttributeDto>();
            CreateMap<AttributeDto, ProductAttribute>();
        }
    }
}
