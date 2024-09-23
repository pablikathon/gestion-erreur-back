using AutoMapper;
using Persist.Entities;
using Persist.Entities.BaseTable;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public void MappingProfileCustomer()
    {
        CreateMap<CreateCustomerRequest, CustomerEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateCustomerRequest,CustomerEntity >()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}