using AutoMapper;
using Persist.Entities.JoiningTable;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public void MappingProfileApplicationDeployement()
    {
        CreateMap<CreateApplicationDeployedRequest, ApplicationDeployedOnServerEntity>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateApplicationDeployedRequest, ApplicationDeployedOnServerEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}