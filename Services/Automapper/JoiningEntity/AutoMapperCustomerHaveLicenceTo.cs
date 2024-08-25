using AutoMapper;
using Persist.Entities;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public void MappingProfileCustomerHaveLicence()
    {
        CreateMap<CreateCustomerHasLicenceToRequest, CustomerHaveLicenceToApplicationEntity>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateCustomerHasLicenceRequest, CustomerHaveLicenceToApplicationEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
