using AutoMapper;

using Persist.Entities.JoiningTable;

using Services.Models.Command;

public partial class MappingProfile : Profile
{
    public void MappingProfileApplicationDeployement()
    {
        CreateMap<CreateApplicationDeployedCommand, ApplicationDeployedOnServerEntity>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateApplicationDeployedCommand, ApplicationDeployedOnServerEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
