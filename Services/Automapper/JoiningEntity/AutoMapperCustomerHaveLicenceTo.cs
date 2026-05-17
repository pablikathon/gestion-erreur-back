using AutoMapper;

using Persist.Entities;

using Services.Models.Command;

public partial class MappingProfile : Profile
{
    public void MappingProfileCustomerHaveLicence()
    {
        CreateMap<CreateCustomerHasLicenceToCommand, CustomerHaveLicenceToApplicationEntity>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateCustomerHasLicenceCommand, CustomerHaveLicenceToApplicationEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
