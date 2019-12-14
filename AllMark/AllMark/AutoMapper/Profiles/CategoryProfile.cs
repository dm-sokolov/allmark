using AllMark.Core.Models;
using AllMark.DTO;
using AutoMapper;

namespace AllMark.AutoMapper.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
