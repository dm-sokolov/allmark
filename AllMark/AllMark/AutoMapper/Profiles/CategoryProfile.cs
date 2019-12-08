using AllMark.DTO;
using AutoMapper;
using Utils.NationalCatalog.Models;

namespace AllMark.AutoMapper.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CatalogCategory, CategoryDto>();
        }
    }
}
