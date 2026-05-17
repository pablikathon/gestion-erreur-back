using AutoMapper;

using Persist.Entities.BaseTable;

using Services.Models.Command;


public partial class MappingProfile : Profile
{
    public void MappingProfileServer()
    {
        CreateMap<CreateServerCommand, ServerEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateServerCommand, ServerEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
