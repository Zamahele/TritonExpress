using AutoMapper;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Infrastructure.ViewModel;

namespace TritonExpress.API.Infrastructure.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<CustomerModel, Customer>()
            //    .ForMember(dest => dest.Id,
            //            opt => opt.MapFrom(src => src.CustomerId))
            //    .ReverseMap();
        }
    }
}
