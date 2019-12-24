using AllMark.Core.Models;
using AllMark.DTO;
using AllMark.Models;
using AutoMapper;

namespace AllMark.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<RegisterViewModel, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
